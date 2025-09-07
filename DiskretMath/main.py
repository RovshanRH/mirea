import re
import math

with open("Assets/test.txt", mode="r+") as f:
    with open("Assets/new_text.txt", mode="w") as file:
        for line in f.readlines():
            new_line = re.sub(r'[.,!?;:"\'`\-—–()\[\]{}\s]', '', line)
            new_line = new_line.lower()
            file.write(new_line)

with open("Assets/new_text.txt", mode="r") as f:
    data = {}
    lines = f.readline()
    for i in lines:
        if i not in data:
            data[i] = 1
        else:
            data[i] += 1

    data_2 = {}
    for i in range(len(lines)-1):
        if lines[i]+lines[i+1] not in data_2:
            data_2[lines[i]+lines[i+1]] = 1
        else:
            data_2[lines[i]+lines[i+1]] += 1

print("Частота появления однобуквенных сочетаний: ", data)
print("Частота появления двухбуквенных сочетаний: ", data_2)

H1, H2 = 0, 0
P1, P2 = [], []
for i in data:
    P1.append(data.get(i)/14)
for i in data_2:
    P2.append(data_2.get(i)/13)

for i in P1:
    H1 += (-1)*i * math.log(i, 2)
for i in P2:
    H2 += (-1)*i * math.log(i, 2)

print(f"Энтропия, приходящаяся в среднем на 1 букву: {H1},\nНа 2 буквы: {H2} ")
code_length = math.ceil(math.log(len(data), 2))
print(f"Длина кода при равномерном кодировании на однобуквенных сочетаний: {code_length}")
print(f"Избыточность: {((code_length - H1)/code_length)}%")


