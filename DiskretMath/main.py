import re
import math


H1, H2 = 0, 0
P1, P2 = [], []

with open("Assets/text.txt", mode="r+") as f:
    with open("Assets/new_text.txt", mode="w") as file:
        for line in f.readlines():
            new_line = re.sub(r'[.,!?;:"\'`\-—–()\[\]{}\s]', '', line)
            new_line = new_line.lower()
            file.write(new_line)

with open("Assets/new_text.txt", mode="r") as f:
    lines = f.readline()
    textLength = len(lines)
    
    # Подсчет однобуквенных сочетаний
    data = {}
    for i in lines:
        if i not in data:
            data[i] = 1
        else:
            data[i] += 1

    # Подсчет двухбуквенных сочетаний
    data_2 = {}
    for i in range(len(lines)-1):
        if lines[i]+lines[i+1] not in data_2:
            data_2[lines[i]+lines[i+1]] = 1
        else:
            data_2[lines[i]+lines[i+1]] += 1

    # Расчет энтропии для исходных данных
    for i in data:
        P1.append(data.get(i)/textLength)
    for i in data_2:
        P2.append(data_2.get(i)/(textLength-1))

    H1_original = 0
    for i in P1:
        H1_original += (-1)* i * math.log(i, 2)
    
    H2_original = 0
    for i in P2:
        H2_original += (-1)* i * math.log(i, 2)

    # Сортировка данных по частоте
    sortedData = sorted(data.items(), key=lambda item: item[1], reverse=True)
    sortedData_2 = sorted(data_2.items(), key=lambda item: item[1], reverse=True)

    # Шаг 6: Удаление 20% наиболее часто встречающихся символов
    num_to_remove_frequent = max(1, int(len(data) * 0.2))
    frequent_chars = [char for char, freq in sortedData[:num_to_remove_frequent]]
    
    # Создание нового текста без частых символов
    text_without_frequent = ''.join([char for char in lines if char not in frequent_chars])
    
    # Подсчет энтропии после удаления частых символов
    data_frequent = {}
    for char in text_without_frequent:
        if char not in data_frequent:
            data_frequent[char] = 1
        else:
            data_frequent[char] += 1
    
    H1_frequent = 0
    total_chars_frequent = len(text_without_frequent)
    if total_chars_frequent > 0:
        for char, count in data_frequent.items():
            p = count / total_chars_frequent
            H1_frequent += (-1) * p * math.log(p, 2)
    
    # Шаг 7: Удаление 20% наиболее редко встречающихся символов
    num_to_remove_rare = max(1, int(len(data) * 0.2))
    rare_chars = [char for char, freq in sortedData[-num_to_remove_rare:]]
    
    # Создание нового текста без редких символов
    text_without_rare = ''.join([char for char in lines if char not in rare_chars])
    
    # Подсчет энтропии после удаления редких символов
    data_rare = {}
    for char in text_without_rare:
        if char not in data_rare:
            data_rare[char] = 1
        else:
            data_rare[char] += 1
    
    H1_rare = 0
    total_chars_rare = len(text_without_rare)
    if total_chars_rare > 0:
        for char, count in data_rare.items():
            p = count / total_chars_rare
            H1_rare += (-1) * p * math.log(p, 2)


print("Частота появления однобуквенных сочетаний: ", sortedData)
print("Частота появления двухбуквенных сочетаний: ", sortedData_2)

print(f"\nЭнтропия, приходящаяся в среднем на 1 букву: {H1_original}")
print(f"Энтропия, приходящаяся в среднем на 2 буквы: {H2_original}")

code_length = math.ceil(math.log(len(data), 2))
print(f"Длина кода при равномерном кодировании на однобуквенных сочетаний: {code_length}")
print(f"Избыточность: {((code_length - H1_original)/code_length)*100:.2f}%")

# Анализ результатов шага 6
print(f"Удаленные символы: {frequent_chars}")
print(f"Энтропия после удаления частых символов: {H1_frequent:.4f}")
print(f"Изменение энтропии: {H1_frequent - H1_original:.4f}")

if H1_frequent > H1_original:
    print("Энтропия увеличилась")
elif H1_frequent < H1_original:
    print("Энтропия уменьшилась")
else:
    print("Энтропия не изменилась.")

# Анализ результатов шага 7
print(f"Удаленные символы: {rare_chars}")
print(f"Энтропия после удаления редких символов: {H1_rare:.4f}")
print(f"Изменение энтропии: {H1_rare - H1_original:.4f}")

if H1_rare > H1_original:
    print("Энтропия увеличилась")
elif H1_rare < H1_original:
    print("Энтропия уменьшилась")
else:
    print("Энтропия не изменилась.")