import re

with open("Assets/test.txt", mode="r+") as f:
    with open("Assets/new_text.txt", mode="w") as file:
        for line in f.readlines():
            new_line = re.sub(r'[.,!?;:"\'`\-—–()\[\]{}\s]', '', line)
            new_line = new_line.lower()
            file.write(new_line)

with open("Assets/new_text.txt", mode="w") as f:
    
    