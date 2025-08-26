// TacTicA.FaqSimilaritySearchBot JavaScript Client
class TacTicAFaqSimilaritySearchBot {
    constructor() {
        this.qaData = null;
        this.documentChunks = null;
        this.config = null;
        this.isLoading = false;
        this.messageHistory = [];

        this.initializeElements();
        this.attachEventListeners();
        this.loadData();
    }

    initializeElements() {
        this.chatMessages = document.getElementById('chatMessages');
        this.userInput = document.getElementById('userInput');
        this.sendButton = document.getElementById('sendButton');
        this.statusIndicator = document.getElementById('statusIndicator');
        this.characterCount = document.getElementById('characterCount');
    }

    attachEventListeners() {
        // Send button click
        this.sendButton.addEventListener('click', () => this.handleSendMessage());

        // Enter key press
        this.userInput.addEventListener('keypress', (e) => {
            if (e.key === 'Enter' && !e.shiftKey) {
                e.preventDefault();
                this.handleSendMessage();
            }
        });

        // Character count
        this.userInput.addEventListener('input', () => {
            const length = this.userInput.value.length;
            this.characterCount.textContent = `${length}/500`;
            
            if (length > 450) {
                this.characterCount.classList.add('text-red-500');
            } else {
                this.characterCount.classList.remove('text-red-500');
            }
        });

        // Quick questions
        document.querySelectorAll('.quick-question').forEach(button => {
            button.addEventListener('click', () => {
                this.userInput.value = button.textContent.trim();
                this.handleSendMessage();
            });
        });
    }

    async loadData() {
        try {
            console.log('Loading chatbot data...');
            
            // Try to load data files via fetch first
            try {
                const [qaResponse, chunksResponse, configResponse] = await Promise.all([
                    fetch('data/qa_embeddings.json'),
                    fetch('data/document_chunks.json'),
                    fetch('data/config.json')
                ]);

                if (qaResponse.ok && chunksResponse.ok && configResponse.ok) {
                    this.qaData = await qaResponse.json();
                    this.documentChunks = await chunksResponse.json();
                    this.config = await configResponse.json();
                    
                    console.log('Data loaded successfully via fetch:', {
                        qaCount: this.qaData?.length || 0,
                        chunkCount: this.documentChunks?.length || 0,
                        config: this.config
                    });

                    this.showSystemMessage('✅ Chatbot is ready! Ask me any [Chromium codebase] question.', 'success');
                    return;
                }
            } catch (fetchError) {
                console.log('Fetch failed, falling back to embedded data:', fetchError.message);
            }
            
            // Fallback: Use embedded data or show instructions
            console.log('Using fallback mode - limited functionality');
            this.qaData = [];
            this.documentChunks = [];
            this.config = {
                createdAt: new Date().toISOString(),
                qaCount: 0,
                documentChunkCount: 0,
                embeddingDimension: 384,
                defaultSimilarityThreshold: 0.9
            };
            
            this.showSystemMessage('⚠️ Running in limited mode. To enable full functionality, please serve this application via HTTP server (e.g., python -m http.server 8080 or node server.js)', 'error');
            
        } catch (error) {
            console.error('Failed to load chatbot data:', error);
            this.showSystemMessage(
                '⚠️ Unable to load chatbot data. Please ensure the training process has been completed and data files exist.',
                'error'
            );
        }
    }

    async handleSendMessage() {
        const message = this.userInput.value.trim();
        if (!message || this.isLoading) return;

        // Clear input
        this.userInput.value = '';
        this.characterCount.textContent = '0/500';

        // Add user message
        this.addMessage(message, 'user');

        // Show typing indicator
        this.setLoading(true);
        this.addTypingIndicator();

        try {
            const response = await this.processMessage(message);
            this.removeTypingIndicator();
            this.addBotResponse(response);
        } catch (error) {
            console.error('Error processing message:', error);
            this.removeTypingIndicator();
            this.showSystemMessage('Sorry, I encountered an error processing your question. Please try again.', 'error');
        } finally {
            this.setLoading(false);
        }
    }

    async processMessage(userQuestion) {
        const startTime = Date.now();
        
        // First, validate if the input looks like a legitimate question
        if (!this.isValidQuestion(userQuestion)) {
            return {
                isValid: false,
                isRag: false,
                answer: "I don't seem to be able to find a question relevant to the [Chromium codebase] process. Try to rephrase your question or use proper wording, grammar and syntax. Thank you!",
                sources: [],
                confidence: 0,
                responseType: 'INVALID',
                processingTimeMs: Date.now() - startTime
            };
        }
        
        // Normalize the question for better matching
        const normalizedQuestion = this.normalizeQuestion(userQuestion);
        console.log('Original question:', userQuestion);
        console.log('Normalized question:', normalizedQuestion);
        
        // If no data is loaded, provide fallback response
        if (!this.qaData || !this.documentChunks || this.qaData.length === 0) {
            return {
                isValid: false,
                isRag: false,
                answer: `I'm currently running in limited mode without access to the [Chromium codebase] knowledge base.`,
                sources: [],
                confidence: 0,
                responseType: 'LIMITED',
                processingTimeMs: Date.now() - startTime
            };
        }
        
        // Step 1: Try FAQ matching
        const faqResult = this.findBestFAQMatch(normalizedQuestion);
        const threshold = this.config?.defaultSimilarityThreshold || 0.85; // Lowered from 0.90

        console.log(`FAQ matching: score=${faqResult.score}, threshold=${threshold}`);

        if (faqResult.score >= threshold) {
            // FAQ hit - get documents from the FAQ answer
            console.log('FAQ match found:', faqResult);
            const relevantChunks = this.findRelevantDocuments(normalizedQuestion, faqResult.qa.wikiLinks);
            
            return {
                isValid: true,
                isRag: false,
                answer: this.generateFAQResponse(faqResult.qa, relevantChunks),
                sources: this.formatSources(relevantChunks),
                confidence: faqResult.score,
                responseType: 'FAQ',
                processingTimeMs: Date.now() - startTime
            };
        } else {
            // RAG fallback - search all documents
            console.log('Using RAG fallback, FAQ score too low:', faqResult.score);
            const relevantChunks = this.findRelevantDocuments(normalizedQuestion);
            
            return {
                isValid: true,
                isRag: true,
                answer: this.generateRAGResponse(userQuestion, relevantChunks),
                sources: this.formatSources(relevantChunks),
                confidence: relevantChunks.length > 0 ? Math.max(...relevantChunks.map(c => c.score)) : 0,
                responseType: 'RAG',
                processingTimeMs: Date.now() - startTime
            };
        }
    }

    isValidQuestion(userInput) {
        // Normalize the input
        const input = userInput.toLowerCase().trim();
        
        // Check minimum length (too short probably not a real question)
        if (input.length < 5) {
            return false;
        }
        
        // Check for completely random/gibberish input
        const gibberishPatterns = [
            /^[^a-zA-Z]*$/,  // Only numbers/symbols
            /(.)\1{4,}/,     // Repeated characters (aaaaa, 11111)
            /^[qwertyuiop]+$|^[asdfghjkl]+$|^[zxcvbnm]+$/,  // Keyboard mashing
        ];
        
        for (const pattern of gibberishPatterns) {
            if (pattern.test(input)) {
                return false;
            }
        }
        
        // Check for [Chromium codebase]-related keywords (at least one should be present for context)
        const topicKeywords = [
            'chromium', 'chrome', 'browser', 'google', 'c++', 'ninja', 'code', 'script', 'html',
            'cmake', 'gn', 'unittest', 'unit', 'test', 'gtest', 'gclient', 'include', 'toolchain', 'pnacl', 'nativ', 'platf',
            'sandbox', 'commit', 'pullreq', 'clang', 'cl', 'client', 'release', 'debug', 'device', 'css', 'function', 'memory', 'access', 'struct', 'schema',
            'source', 'static', 'unsafe', 'bindgen', 'cxx', 'extern', 'bridge', 'librar', 'tutorial', 'thread', 'buffer', 'generat',
            'grd', 'grdp', 'pak', 'resource', 'icu', 'pipeline', 'web', 'webui',
            'test', 'deploy', 'build', 'rust', 'v8', 'javascript', 'wasm', 'webassembly',
            'how', 'what', 'where', 'when', 'why', 'which', 'can', 'do', 'does',
            'help', 'guid', 'process', 'work', 'fix', 'problem',
            'add', 'creat', 'updat', 'chang', 'handl', 'manag', 'configur'
        ];
        
        const hasRelevantKeyword = topicKeywords.some(keyword => 
            input.includes(keyword)
        );
        
        // Check for question indicators
        const questionIndicators = [
            // Question words
            input.startsWith('how'), input.startsWith('what'), input.startsWith('where'),
            input.startsWith('when'), input.startsWith('why'), input.startsWith('which'),
            input.startsWith('can'), input.startsWith('do'), input.startsWith('does'),
            input.startsWith('should'), input.startsWith('would'), input.startsWith('could'),
            // Question marks
            input.includes('?'),
            // Help requests
            input.includes('help'), input.includes('need'), input.includes('want'),
            // Process requests  
            input.includes('guide'), input.includes('step'), input.includes('process')
        ];
        
        const hasQuestionIndicator = questionIndicators.some(indicator => indicator === true);
        
        // Must have either relevant keyword OR question indicator (or both)
        if (!hasRelevantKeyword && !hasQuestionIndicator) {
            return false;
        }
        
        // Check for obviously unrelated content
        const unrelatedPatterns = [
            /weather|climate|temperature|breakfast/i,
            /food|recipe|cooking|cafe|lunch|dinner|restaurant/i,
            /sports|football|basketball|soccer|boat/i,
            /movie|film|tv|television|netflix/i,
            /music|song|artist|album/i,
            /game|gaming|xbox|playstation/i,
            /politics|election|president|government/i,
            /health|medicine|doctor|hospital/i,
            /travel|vacation|hotel|flight/i,
            /fashion|clothes|shopping|style/i
        ];
        
        for (const pattern of unrelatedPatterns) {
            if (pattern.test(input)) {
                return false;
            }
        }
        
        return true;
    }

    // Updated to accept precomputed user embedding
    findBestFAQMatch(userQuestion) {
        const userEmbedding = this.generateSimpleEmbedding(userQuestion);
        let bestMatch = null;
        let bestScore = -1;

        this.qaData.forEach(qa => {
            if (qa.embedding && qa.embedding.length > 0) {
                const score = this.cosineSimilarity(userEmbedding, qa.embedding);
                if (score > bestScore) {
                    bestScore = score;
                    bestMatch = qa;
                }
            }
        });

        return {
            qa: bestMatch,
            score: bestScore
        };
    }

    // Updated to accept precomputed user embedding and optional URL filter
    findRelevantDocuments(userQuestion, specificUrls = null, topK = 5) {
        const userEmbedding = this.generateSimpleEmbedding(userQuestion);
        const candidates = specificUrls 
            ? this.documentChunks.filter(chunk =>
              specificUrls.some(url => chunk.sourceUrl.includes(url) || url.includes(chunk.sourceUrl)))
            : this.documentChunks;

        // Enhanced scoring with text similarity boost
        const scored = candidates
            .filter(chunk => chunk.embedding && chunk.embedding.length > 0)
            .map(chunk => {
                const vectorScore = this.cosineSimilarity(userEmbedding, chunk.embedding);
                
                // Add text-based similarity boost for better matching
                const textScore = this.calculateTextSimilarity(userQuestion.toLowerCase(), chunk.content.toLowerCase());
                const titleScore = this.calculateTextSimilarity(userQuestion.toLowerCase(), (chunk.title || '').toLowerCase());
                
                // Combine scores: 70% vector similarity, 20% content similarity, 10% title similarity
                const finalScore = (vectorScore * 0.7) + (textScore * 0.2) + (titleScore * 0.1);
                
                return {
                    ...chunk,
                    score: finalScore,
                    vectorScore,
                    textScore,
                    titleScore
                };
            })
            .sort((a, b) => b.score - a.score)
            .slice(0, topK);

        console.log(`Found ${scored.length} relevant documents from ${candidates.length} candidates`, 
          scored.slice(0, 3).map(s => ({
            title: s.title,
            score: s.score,
            vectorScore: s.vectorScore,
            textScore: s.textScore
        })));
        return scored;
    }

    calculateTextSimilarity(text1, text2) {
        // Simple keyword-based similarity for boosting relevant matches
        const words1 = text1.split(/\s+/).filter(w => w.length > 2);
        const words2 = text2.split(/\s+/).filter(w => w.length > 2);
        
        let matchCount = 0;
        words1.forEach(word => {
            if (words2.some(w2 => w2.includes(word) || word.includes(w2))) {
                matchCount++;
            }
        });
        
        return words1.length > 0 ? matchCount / words1.length : 0;
    }

    generateFAQResponse(qa, relevantChunks) {
        const responseArray = [];
        
        // Add FAQ answer as first item (mandatory)
        responseArray.push(`Based on our FAQ, here's the answer to your question:\n\n${qa.answer}`);

        // TODO AY I AM COMMENTING THIS OUT, as MARKUP itself is UGLY and not helpful for now.
        
        // if (relevantChunks.length > 0) {
        //     // Add each chunk as a separate item
        //     relevantChunks.slice(0, 3).forEach((chunk, index) => {
        //         let chunkResponse = `##### ${index + 1}. From ${chunk.title}\n\n`;
                
        //         // Show more detailed content for FAQ responses too
        //         let content = chunk.content;
        //         content = content.replace(/^TITLE:.*\n/gm, '');
        //         content = content.replace(/^URL:.*\n/gm, '');
        //         content = content.replace(/^LAST_UPDATED:.*\n/gm, '');
                
        //         if (content.length > 600) {
        //             const cutPoint = content.lastIndexOf('\n', 600) || content.lastIndexOf('. ', 600) || 600;
        //             content = content.substring(0, cutPoint) + '...\n\n*[Content truncated - see source for details]*';
        //         }
                
        //         chunkResponse += content;
        //         responseArray.push(chunkResponse);
        //     });
        // }

        return responseArray;
    }

    generateRAGResponse(userQuestion, relevantChunks) 
    {
        if (relevantChunks.length === 0) 
        {
            return [`I don't have specific information about "${userQuestion}" in my [Chromium codebase] knowledge base. You might want to:

1. Check the [Chromium codebase] documentation
2. Contact the [Chromium codebase] team directly
3. Search the internal wiki for more specific information

Is there a different way I can help you with your [Chromium codebase] question?`];
        }

        // Create array of response strings
        const responseArray = [];
        
        // TODO AY I AM COMMENTING THIS OUT, as MARKUP itself is UGLY and not helpful for now.

        // // Add header as first item (mandatory)
        // responseArray.push(`Here are relevant sections from our documentation regarding your question:`);
        
        // // Add each chunk as a separate item
        // relevantChunks.slice(0, 3).forEach((chunk, index) => {
        //     let chunkResponse = `##### ${index + 1}. ${chunk.title}\n\n`;
            
        //     // Show more content and clean it up
        //     let content = chunk.content;

        //     // Show more content (up to 800 characters instead of 300)
        //     if (content.length > 800) {
        //         const cutPoint = 100;
        //         content = content.substring(0, cutPoint) + '...\n\n*[Content truncated - see source for full details]*';
        //     }
            
        //     chunkResponse += content;
        //     responseArray.push(chunkResponse);
        // });

        // Add footer as last item
        responseArray.push(`For complete details, please refer to the source links provided above.`);

        return responseArray;
    }

    formatSources(chunks) {
        const uniqueUrls = [...new Set(chunks.map(chunk => chunk.sourceUrl))];
        return uniqueUrls.slice(0, 5).map((url, index) => {
            const chunk = chunks.find(c => c.sourceUrl === url);
            return {
                id: chunk?.id || `source-${index}`,
                score: chunk?.score || 0,
                content: chunk?.content?.substring(0, 100) + '...' || '',
                sourceUrl: url,
                title: chunk?.title || 'Documentation',
                section: chunk?.section || ''
            };
        });
    }

    // Simple embedding generation (deterministic hash-based) - fallback only - matches C# implementation
    generateSimpleEmbedding(text) 
    {
        const dimension = 384; // Match the training service
        
        // Normalize text for consistent embedding generation
        const normalizedText = this.normalizeText(text);
        
        // Generate deterministic embeddings based on text hash - matching C# GetHashCode behavior
        const hash = this.getHashCode(normalizedText);
        const random = this.seededRandom(hash);
        
        const embedding = new Array(dimension);
        for (let i = 0; i < dimension; i++) {
            embedding[i] = random() * 2 - 1; // Range [-1, 1]
        }

        // Normalize the vector
        const magnitude = Math.sqrt(embedding.reduce((sum, val) => sum + val * val, 0));
        for (let i = 0; i < embedding.length; i++) {
            embedding[i] = magnitude > 0 ? embedding[i] / magnitude : 0;
        }

        return embedding;
    }

    // Simple hash function to approximate C# GetHashCode
    getHashCode(str) {
        let hash = 0;
        if (str.length === 0) return hash;
        for (let i = 0; i < str.length; i++) {
            const char = str.charCodeAt(i);
            hash = ((hash << 5) - hash) + char;
            hash = hash & hash; // Convert to 32bit integer
        }
        return Math.abs(hash);
    }

    // Seeded random number generator
    seededRandom(seed) {
        return function() {
            seed = (seed * 9301 + 49297) % 233280;
            return seed / 233280;
        };
    }

    cosineSimilarity(a, b) {
        if (a.length !== b.length) return 0;

        let dotProduct = 0;
        let normA = 0;
        let normB = 0;

        for (let i = 0; i < a.length; i++) {
            dotProduct += a[i] * b[i];
            normA += a[i] * a[i];
            normB += b[i] * b[i];
        }

        if (normA === 0 || normB === 0) return 0;
        return dotProduct / (Math.sqrt(normA) * Math.sqrt(normB));
    }

    // Normalize text for consistent embedding generation - matches C# implementation
    normalizeText(text) {
        if (!text || typeof text !== 'string') return '';
        
        // Convert to lowercase and trim whitespace
        return text.toLowerCase().trim();
    }

    addMessage(content, type) {
        const messageDiv = document.createElement('div');
        messageDiv.className = 'flex items-start space-x-3 message-fade-in';

        const avatarDiv = document.createElement('div');
        avatarDiv.className = 'flex-shrink-0';

        const avatarIcon = document.createElement('div');
        if (type === 'user') {
            avatarIcon.className = 'w-8 h-8 bg-blue-600 rounded-full flex items-center justify-center';
            avatarIcon.innerHTML = '<i class="fas fa-user text-white text-sm"></i>';
        } else {
            avatarIcon.className = 'w-8 h-8 bg-green-500 rounded-full flex items-center justify-center';
            avatarIcon.innerHTML = '<i class="fas fa-robot text-white text-sm"></i>';
        }

        avatarDiv.appendChild(avatarIcon);

        const contentDiv = document.createElement('div');
        contentDiv.className = type === 'user' 
            ? 'message-user p-4 rounded-lg shadow-sm' 
            : 'message-bot p-4 rounded-lg shadow-sm';
        
        contentDiv.innerHTML = this.formatMessageContent(content);

        messageDiv.appendChild(avatarDiv);
        messageDiv.appendChild(contentDiv);

        this.chatMessages.appendChild(messageDiv);
        this.scrollToBottom();

        this.messageHistory.push({ type, content, timestamp: Date.now() });
    }

    addBotResponse(response) {
        const messageDiv = document.createElement('div');
        messageDiv.className = 'flex items-start space-x-3 message-fade-in';

        const avatarDiv = document.createElement('div');
        avatarDiv.className = 'flex-shrink-0';
        
        const avatarIcon = document.createElement('div');
        avatarIcon.className = 'w-8 h-8 bg-green-500 rounded-full flex items-center justify-center';
        avatarIcon.innerHTML = '<i class="fas fa-robot text-white text-sm"></i>';
        avatarDiv.appendChild(avatarIcon);

        const contentDiv = document.createElement('div');
        contentDiv.className = 'message-bot p-4 rounded-lg shadow-sm max-w-4xl';

        // Sources
        if (response.isValid && response.sources && response.sources.length > 0) {
            const answerDiv = document.createElement('div');
            answerDiv.innerHTML = "Here is a set of links that you will need to follow:";
            contentDiv.appendChild(answerDiv);

            const sourcesDiv = document.createElement('div');
            sourcesDiv.className = 'sources-container';

            const confidenceTitle = document.createElement('h4');
            confidenceTitle.className = 'font-semibold text-sm text-gray-700 mb-2';
            confidenceTitle.innerHTML = `<span>Answer Confidence:</span>`;
            sourcesDiv.appendChild(confidenceTitle);

            const confidenceValueDiv = document.createElement('div');
            confidenceValueDiv.className = 'source-item';
            const confidenceValueClass = response.confidence > 0.8 ? 'confidence-high' : 
                                    response.confidence > 0.6 ? 'confidence-medium' : 'confidence-low';
            confidenceValueDiv.innerHTML = `<span class="confidence-badge ${confidenceValueClass}">${Math.round(response.confidence * 100)}%</span>`;
            sourcesDiv.appendChild(confidenceValueDiv);

            const sourcesTitle = document.createElement('h4');
            sourcesTitle.className = 'font-semibold text-sm text-gray-700 mb-2';
            sourcesTitle.innerHTML = '<i class="fas fa-link mr-1"></i> Sources:';
            sourcesDiv.appendChild(sourcesTitle);

            response.sources.forEach((source, index) => {
                const sourceDiv = document.createElement('div');
                sourceDiv.className = 'source-item';
                
                const confidenceClass = source.score > 0.8 ? 'confidence-high' : 
                                      source.score > 0.6 ? 'confidence-medium' : 'confidence-low';
                
                sourceDiv.innerHTML = `
                    <span class="confidence-badge ${confidenceClass}">
                        ${Math.round(source.score * 100)}%
                    </span>
                    <a href="${source.sourceUrl}" target="_blank" class="source-link flex-1">
                        <i class="fas fa-external-link-alt mr-1"></i>
                        ${source.title} ${source.section ? `- ${source.section}` : ''}
                    </a>
                `;
                
                sourcesDiv.appendChild(sourceDiv);
            });

            contentDiv.appendChild(sourcesDiv);

            // Handle array of answer strings
            if (Array.isArray(response.answer)) {
                response.answer.forEach((answerItem, index) => {
                    const answerDiv = document.createElement('div');
                    answerDiv.className = `mmargin answer-section answer-section-${index}`;
                    answerDiv.innerHTML = this.formatMessageContent(answerItem);
                    contentDiv.appendChild(answerDiv);
                });
            } else {
                // Fallback for single string (backward compatibility)
                const followUpDiv = document.createElement('div');
                followUpDiv.className = 'mmargin';
                followUpDiv.innerHTML = this.formatMessageContent(response.answer);
                contentDiv.appendChild(followUpDiv);
            }
        } else {
            // Handle array of answer strings
            if (Array.isArray(response.answer)) {
                response.answer.forEach((answerItem, index) => {
                    const answerDiv = document.createElement('div');
                    answerDiv.className = `mmargin answer-section answer-section-${index}`;
                    answerDiv.innerHTML = this.formatMessageContent(answerItem);
                    contentDiv.appendChild(answerDiv);
                });
            } else {
                // Fallback for single string (backward compatibility)
                const followUpDiv = document.createElement('div');
                followUpDiv.className = 'mmargin';
                followUpDiv.innerHTML = this.formatMessageContent(response.answer);
                contentDiv.appendChild(followUpDiv);
            }
        }

        // Response metadata
        const metaDiv = document.createElement('div');
        metaDiv.className = 'mt-3 pt-3 border-t border-gray-200 text-xs text-gray-500 flex justify-between';
        metaDiv.innerHTML = `
            <span>
                <i class="fas fa-bolt mr-1"></i>
                ${response.responseType} • ${response.processingTimeMs}ms
            </span>
            <span>
                Confidence: ${Math.round(response.confidence * 100)}%
            </span>
        `;
        contentDiv.appendChild(metaDiv);

        messageDiv.appendChild(avatarDiv);
        messageDiv.appendChild(contentDiv);

        this.chatMessages.appendChild(messageDiv);
        this.scrollToBottom();

        this.messageHistory.push({ 
            type: 'bot', 
            content: response, 
            timestamp: Date.now() 
        });
    }

    addTypingIndicator() {
        const typingDiv = document.createElement('div');
        typingDiv.id = 'typingIndicator';
        typingDiv.className = 'flex items-start space-x-3';

        const avatarDiv = document.createElement('div');
        avatarDiv.className = 'flex-shrink-0';
        
        const avatarIcon = document.createElement('div');
        avatarIcon.className = 'w-8 h-8 bg-green-500 rounded-full flex items-center justify-center';
        avatarIcon.innerHTML = '<i class="fas fa-robot text-white text-sm"></i>';
        avatarDiv.appendChild(avatarIcon);

        const contentDiv = document.createElement('div');
        contentDiv.className = 'message-bot p-4 rounded-lg shadow-sm';
        contentDiv.innerHTML = `
            <div class="typing-indicator">
                <div class="typing-dot"></div>
                <div class="typing-dot"></div>
                <div class="typing-dot"></div>
                <span class="ml-2 text-gray-600">Thinking...</span>
            </div>
        `;

        typingDiv.appendChild(avatarDiv);
        typingDiv.appendChild(contentDiv);

        this.chatMessages.appendChild(typingDiv);
        this.scrollToBottom();
    }

    removeTypingIndicator() {
        const typingIndicator = document.getElementById('typingIndicator');
        if (typingIndicator) {
            typingIndicator.remove();
        }
    }

    showSystemMessage(message, type = 'info') {
        const messageDiv = document.createElement('div');
        messageDiv.className = `flex justify-center mb-4 message-fade-in`;

        const contentDiv = document.createElement('div');
        const bgClass = type === 'error' ? 'message-error' : 
                       type === 'success' ? 'bg-green-50 border-green-200 text-green-800' :
                       'bg-blue-50 border-blue-200 text-blue-800';
        
        contentDiv.className = `${bgClass} px-4 py-2 rounded-lg text-sm border`;
        contentDiv.textContent = message;

        messageDiv.appendChild(contentDiv);
        this.chatMessages.appendChild(messageDiv);
        this.scrollToBottom();
    }

    formatMessageContent(content) {
        // Convert markdown-like formatting to HTML
        // Enhanced markdown detection
        const hasMarkdownElements = /^#{1,6}\s|^\*\s|^\-\s|^\d+\.\s|```|`[^`]+`|\*\*[^*]+\*\*|\*[^*]+\*|\[.+\]\(.+\)|https?:\/\/[^\s]+/.test(content);
        
        console.log('Formatting content:', { hasMarkdownElements, markedAvailable: typeof marked !== 'undefined', contentPreview: content.substring(0, 100) });
        
        if (hasMarkdownElements && typeof marked !== 'undefined') {
            try {
                // Configure marked for better rendering
                marked.setOptions({
                    breaks: true,
                    gfm: true,
                    headerIds: false,
                    mangle: false,
                    sanitize: false,
                    smartLists: true,
                    smartypants: false
                });
                
                // Parse markdown to HTML
                const result = marked.parse(content);
                console.log('Marked parsing successful:', result.substring(0, 200));
                return result;
            } catch (error) {
                console.warn('Marked parsing failed, falling back to manual parsing:', error);
                // Fall through to manual parsing
            }
        }
        
        console.log('Using manual parsing');
        
        // Enhanced manual formatting as fallback
        let formattedContent = content;
        
        // Handle markdown links [text](url)
        formattedContent = formattedContent.replace(/\[([^\]]+)\]\(([^)]+)\)/g, '<a href="$2" target="_blank" rel="noopener noreferrer">$1</a>');
        
        // Handle bare URLs
        formattedContent = formattedContent.replace(/(https?:\/\/[^\s<>"{}|\\^`\[\]]+)/g, '<a href="$1" target="_blank" rel="noopener noreferrer">$1</a>');
        
        // Handle headers
        formattedContent = formattedContent.replace(/^##### (.*$)/gm, '<h3>$1</h3>'); // Special case - our header
        formattedContent = formattedContent.replace(/^### (.*$)/gm, '<h4>$1</h4>');
        formattedContent = formattedContent.replace(/^## (.*$)/gm, '<h4>$1</h4>'); // Don't really make a diff.
        formattedContent = formattedContent.replace(/^# (.*$)/gm, '<h4>$1</h4>'); // Don't really make a diff.
        
        // Handle bold and italic
        formattedContent = formattedContent.replace(/\*\*(.*?)\*\*/g, '<strong>$1</strong>');
        formattedContent = formattedContent.replace(/\*(.*?)\*/g, '<em>$1</em>');
        
        // Handle inline code
        formattedContent = formattedContent.replace(/`(.*?)`/g, '<code class="bg-gray-100 px-1 py-0.5 rounded text-sm">$1</code>');
        
        // Handle code blocks
        formattedContent = formattedContent.replace(/```([\s\S]*?)```/g, '<pre><code>$1</code></pre>');
        
        // Handle lists
        formattedContent = formattedContent.replace(/^[\*\-]\s+(.*)$/gm, '<li>$1</li>');
        formattedContent = formattedContent.replace(/^(\d+)\.\s+(.*)$/gm, '<li>$2</li>');
        
        // Wrap consecutive list items in ul tags (simplified approach)
        formattedContent = formattedContent.replace(/(<li>.*?<\/li>(?:<br><li>.*?<\/li>)*)/g, '<ul>$1</ul>');
        formattedContent = formattedContent.replace(/<\/li><br><li>/g, '</li><li>');
        
        // Handle horizontal rules
        formattedContent = formattedContent.replace(/^---+$/gm, '<hr>');
        
        // Handle line breaks (do this last)
        formattedContent = formattedContent.replace(/\n/g, '<br>');
        
        return formattedContent;
    }

    setLoading(loading) {
        this.isLoading = loading;
        this.sendButton.disabled = loading;
        this.userInput.disabled = loading;
        
        if (loading) {
            this.statusIndicator.classList.remove('hidden');
            this.sendButton.classList.add('loading');
        } else {
            this.statusIndicator.classList.add('hidden');
            this.sendButton.classList.remove('loading');
        }
    }

    scrollToBottom() {
        this.chatMessages.scrollTop = this.chatMessages.scrollHeight;
    }
}

// Initialize the chatbot when the DOM is loaded
document.addEventListener('DOMContentLoaded', () => {
    window.chatBot = new TacTicAFaqSimilaritySearchBot();
});
