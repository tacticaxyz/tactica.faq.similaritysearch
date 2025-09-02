
import os
import shutil

source_dir = r"d:\\my-projects\\tactica.xyz\\tactica.faq.similaritysearch\\src\\TacTicA.FaqSimilaritySearchBot.Training\\data\\exported-content\\"

# Traverse the directory tree
for root, dirs, files in os.walk(source_dir):
    for file in files:
        if file.endswith(".md"):
            # Full path of the source file
            source_file_path = os.path.join(root, file)

            # Read first line of file
            with open(source_file_path, 'r', encoding='utf-8') as f:
                print(f"{f.readline()}")
