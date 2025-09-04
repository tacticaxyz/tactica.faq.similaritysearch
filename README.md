# Chromium codebase FAQ Similarity Search Bot

A sophisticated AI-powered chatbot solution designed to help users quickly find answers to [Chromium codebase] questions. The bot uses vector embeddings and RAG (Retrieval Augmented Generation) to provide accurate, citation-backed responses.

[Play with it In Production]([https://tactica.xyz/#/similarity-search](https://tactica.xyz/#/chromium-similarity-search)

This bot DOES NOT replace ChatGPT, Gemini, Copilot or other super-powerful models. Instead, it can quickly retrieve relevant information from your internal documents.

Essentially, this is a show case of what is possible with similarity search on your internal corporate data, while might not be best example.

![Similarity Search Bot Preview](https://img.shields.io/badge/Status-Ready%20for%20Deployment-green) ![.NET 9](https://img.shields.io/badge/.NET-9.0-purple) ![License](https://img.shields.io/badge/License-MIT-blue)

![Similarity Search Bot](https://github.com/tacticaxyz/tactica.faq.similaritysearch/blob/main/images/tactica-faq-ai-small.png)

## 🌟 Features

- **Smart FAQ Matching**: Uses vector embeddings for intelligent question matching
- **RAG Fallback**: Searches entire document corpus when FAQ doesn't match
- **Citation-Based Responses**: Every answer includes sources and confidence scores
- **Static Deployment**: Runs entirely in the browser - perfect for GitHub Pages
- **Responsive Design**: Works on desktop and mobile devices
- **Real-time Processing**: Fast in-memory vector search with cosine similarity

## 🏗️ Architecture

### Phase 1: Context Database Preparation
- Vector embeddings of Q&A pairs using sentence transformers
- Fast in-memory vector index for similarity search
- Configurable similarity threshold for FAQ matching

### Phase 2: User Query Processing
- FAQ matching with similarity threshold (default: 0.90)
- RAG fallback for document retrieval when FAQ confidence is low
- Citation-based responses with confidence scores

### Phase 3: General Knowledge Retrieval
- Full document corpus search for unmatched queries
- Top-K retrieval with similarity ranking
- Synthesized answers with source attribution

## 📁 Project Structure

```
tactica.faq.similaritysearch/
├── src/
│   ├── TacTicA.FaqSimilaritySearchBot.Training/     
│   │   ├── Program.cs                      # C# training pipeline
│   │   ├── Services/                       # Vector embedding generation services
│   │   │   ├── SimpleEmbeddingService.cs      # Based on simplest hash-based vectors embeddings
│   │   │   ├── TfIdfEmbeddingService.cs       # Based on TF-IDF Vectorization and Keyword-Based Similarity
│   │   │   ├── OnnxEmbeddingService.cs        # Based on pre-trained Transformer Models (Customizable!)
│   │   │   └── DataProcessingService.cs       # Data processing & chunking
│   │   ├── models/                         # Input models files
│   │   │   ├── model_tokenizer.json           # https://huggingface.co/sentence-transformers/all-MiniLM-L6-v2
│   │   │   ├── model_vocab.txt                # https://huggingface.co/sentence-transformers/all-MiniLM-L6-v2
│   │   │   └── model.onnx                     # https://huggingface.co/sentence-transformers/all-MiniLM-L6-v2
│   │   └── data/                           # Input data files
│   │       ├── questions_answers.txt          # Q&A pairs (you provide)
│   │       ├── wiki_links.txt                 # Wiki URLs (you provide)
│   │       └── exported-content/              # Exported content to work in full isolation
│   ├── TacTicA.FaqSimilaritySearchBot.Web/    # Static web application for simple hash-based similarity search
│   │   ├── index.html                              # Main UI
│   │   ├── css/style.css                           # Styling
│   │   └── js/chatbot.js                           # Client-side logic
│   ├── TacTicA.FaqSimilaritySearchBot.WebOnnx/  # Static web application for AI based search
│   │   ├── index.html                                  # Main UI
│   │   ├── css/style.css                               # Styling
│   │   └── js/chatbot.js                               # Client-side logic
│   └── TacTicA.FaqSimilaritySearchBot.Shared/  # Shared models and utilities
│       ├── Models/Models.css
│       └── Utils/VectorUtils.cs
├── wwwroot/data/                               # Generated embeddings & data
├── build.ps1                                   # Build & Training script
└── TacTicA.FaqSimilaritySearchBot.sln
```

## 🚀 Quick Start

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Python 3.x](https://python.org/downloads) (optional, for local web server)
- [Visual Studio Code](https://code.visualstudio.com) or Visual Studio

### 1. Clone and Setup

```powershell
git clone <your-repo-url>
cd tactica.faq.similaritysearch
```

### 2. Data

Data files in the `TacTicA.FaqSimilaritySearchBot.Training/data/` directory:

**`data/questions_answers.txt`** (Q&A pairs, one per 2 lines):
```
Q: Where is android webview build instructions?
A: https://source.chromium.org/chromium/chromium/src/+/main:android_webview/docs/build-instructions.md

Q: What are frame trees in Chromium?
A: https://source.chromium.org/chromium/chromium/src/+/main:docs/frame_trees.md
```

**`data/wiki_links.txt`** (one URL per line):
```
https://source.chromium.org/chromium/chromium/src/+/main:docs/documentation_best_practices.md
https://source.chromium.org/chromium/chromium/src/+/main:docs/fuchsia/gtests.md
```

**`data/exported-content`**

Put as many as required exported content files in a simple markdown format into this directory. It allows system to work in full isolation without even reading wiki-links which is very helpful in case content is restricted via any type of authentication and you need to make some portion of data available to the bot without over-complicating things.

Format is following (URL is mandatory key field here):

```
URL: https://source.chromium.org/chromium/chromium/src/+/main:docs/fuchsia/gtests.md
# Content in Markdown starts here

Your actual content goes here...
```

### 3. Build and Train

```bash
# Build solution
dotnet restore
# Run training
dotnet build --configuration Release
# OR Build & Run together
cd "[PATH_TO_SOURCES]\src\TacTicA.FaqSimilaritySearchBot.Training" ; dotnet run --configuration Release
```

The process is super straightforward and NOT optimized. So it will run super slow... for couple of hours.

![1](https://github.com/tacticaxyz/tactica.faq.similaritysearch/blob/main/images/builddb.gif)

### 4. Serve Locally

Depending on the similarity search you want to use, make sure `$WebPath` in `build.ps1` points to the right Web Project:
`TacTicA.FaqSimilaritySearchBot.WebOnnx` - for AI based similarity search
`TacTicA.FaqSimilaritySearchBot.Web` - for simplistic hash-based or TF-IDF similarity search

```powershell
# Copy data to web server
Copy-Item -Path "[PATH_TO_SOURCES]\src\TacTicA.FaqSimilaritySearchBot.Training\wwwroot\data\*" -Destination "[PATH_TO_SOURCES]\src\TacTicA.FaqSimilaritySearchBot.WebOnnx\data\" -Recurse -Force
# Run
cd "[PATH_TO_SOURCES]\src\TacTicA.FaqSimilaritySearchBot.WebOnnx"; python -m http.server 8080
```

OR
```powershell
# Copy data to web server
Copy-Item -Path "[PATH_TO_SOURCES]\src\TacTicA.FaqSimilaritySearchBot.Training\wwwroot\data\*" -Destination "[PATH_TO_SOURCES]\src\TacTicA.FaqSimilaritySearchBot.Web\data\" -Recurse -Force
# Run
cd "[PATH_TO_SOURCES]\src\TacTicA.FaqSimilaritySearchBot.Web"; python -m http.server 8080
```

## 🔧 Configuration

### Training Configuration (`src/TacTicA.FaqSimilaritySearchBot.Training/appsettings.json`)

```json
{
  "ProcessingSettings": {
    "MaxTokensPerChunk": 500,
    "SimilarityThreshold": 0.90,
    "TopKResults": 5
  }
}
```

### Customizing Embeddings

The current implementation uses three possible embedding services for demo purposes:
── SimpleEmbeddingService - Vector embedding generation based on simplest hash-based vectors embeddings
── TfIdfEmbeddingService - Vector embedding generation based on TF-IDF Vectorization and Keyword-Based Similarity
── OnnxEmbeddingService - Vector embedding generation based on pre-trained sentence transformer model `all-MiniLM-L6-v2` converted to ONNX format

## 📊 Data Flow

1. **Training Phase**:
   ```
   Q&A Text → Embeddings → Vector Index
   Wiki URLs → Content → Chunks → Embeddings → Document Index
   ```

2. **Query Phase**:
   ```
   User Question → Embedding → FAQ Search → High Score?
   ├─ Yes: FAQ Response + Related Docs
   └─ No:  RAG Search → Top Chunks → Generated Response
   ```

## 🔍 Known Issues

**Low Accuracy Responses**:
- We can increase similarity threshold in config
- We may add more Q&A pairs to training data
- Improve existing wiki content quality

**Built with ❤️ AI**
