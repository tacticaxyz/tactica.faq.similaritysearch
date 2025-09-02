
import os
import shutil

source_dir = r"d:\\my-projects\\tactica.xyz\\tactica.faq.similaritysearch\\src\\TacTicA.FaqSimilaritySearchBot.Training\\data\\exported-content\\rust-reference\\"

#URL:https://doc.rust-lang.org/nightly/reference/


# Traverse the directory tree
for root, dirs, files in os.walk(source_dir):
    for file in files:
        if file.endswith(".md"):
            # Full path of the source file
            source_file_path = os.path.join(root, file)
            print(f"Processing {source_file_path}")

            # Relative path from the source directory
            relative_path = os.path.relpath(source_file_path, source_dir)

            # Read the content of the source file
            with open(source_file_path, 'r', encoding='utf-8') as f:
                content = f.read()

            # Prepend the URL line
            url_line = f"URL:https://doc.rust-lang.org/nightly/reference/{relative_path.replace(" ", "-").replace(".md", ".html")}\n"
            new_content = url_line + content

            # Write the new content to the destination file
            with open(source_file_path, 'w', encoding='utf-8') as f:
                f.write(new_content)
