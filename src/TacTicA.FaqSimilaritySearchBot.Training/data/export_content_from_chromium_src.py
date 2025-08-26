
import os
import shutil

# First, clone https://source.chromium.org/chromium/chromium from github or https://source.chromium.org/

# Second, define source and destination directories, so script can traverse repo to find Markdown files
source_dir = r"SOURCE PATH like C:\src"
destination_dir = r"DESTINATION PATH Like C:\temp\docs"

# Traverse the directory tree
for root, dirs, files in os.walk(source_dir):
    for file in files:
        if file.endswith(".md"):
            # Full path of the source file
            source_file_path = os.path.join(root, file)
            print(f"Processing {source_file_path}")

            # Relative path from the source directory
            relative_path = os.path.relpath(source_file_path, source_dir)

            # Destination file path
            destination_file_path = os.path.join(destination_dir, relative_path)

            # Create destination subdirectories if they don't exist
            os.makedirs(os.path.dirname(destination_file_path), exist_ok=True)

            # Read the content of the source file
            with open(source_file_path, 'r', encoding='utf-8') as f:
                content = f.read()

            # Prepend the URL line
            url_line = f"URL:https://source.chromium.org/chromium/chromium/src/+/main:{relative_path}\n"
            new_content = url_line + content

            # Write the new content to the destination file
            with open(destination_file_path, 'w', encoding='utf-8') as f:
                f.write(new_content)
