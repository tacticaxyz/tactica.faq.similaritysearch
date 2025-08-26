import os
import requests
import feedparser
import re
from markdownify import markdownify as md

# Install 
# pip install requests feedparser markdownify

# Everything will be stored in a folder chromium_blog/

BASE_FEED = "https://blog.chromium.org/feeds/posts/default"
OUTPUT_DIR = "chromium_blog"
MAX_RESULTS = 500  # can increase (Blogger max is 500)

def safe_filename(title):
    # Replace forbidden characters with underscore
    return re.sub(r'[\\/*?:"<>|]', "_", title)

os.makedirs(OUTPUT_DIR, exist_ok=True)

def fetch_feed(start_index=1, max_results=MAX_RESULTS):
    url = f"{BASE_FEED}?start-index={start_index}&max-results={max_results}"
    return feedparser.parse(url)

def save_post(entry):
    title = safe_filename(entry.title.replace("/", "_"))
    filename = f"{OUTPUT_DIR}/{title}.md"

    link = entry.link
    published = entry.published
    html_content = entry.content[0].value

    md_content = md(html_content)

    with open(filename, "w", encoding="utf-8") as f:
        f.write(f"URL:{link}\n")
        f.write(f"# {entry.title}\n")
        f.write(f"- **Published**: {published}\n")
        f.write(md_content)

    print(f"Saved {filename}")

def export_blog():
    start = 1
    while True:
        feed = fetch_feed(start)
        if not feed.entries:
            break
        for entry in feed.entries:
            save_post(entry)
        start += MAX_RESULTS

if __name__ == "__main__":
    export_blog()