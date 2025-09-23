import collections
import math
from typing import Dict, List, Tuple

def calculate_entropy(freq: Dict[str, int], total: int) -> float:
    """Рассчитать энтропию Шеннона."""
    entropy = 0.0
    for count in freq.values():
        p = count / total
        if p > 0:
            entropy -= p * math.log2(p)
    return entropy

def shannon_fano(symbols: List[Tuple[str, float]]) -> Dict[str, str]:
    """Построить код Шеннона-Фано."""
    if len(symbols) <= 1:
        return {symbols[0][0]: ''} if symbols else {}
    
    symbols = sorted(symbols, key=lambda x: x[1], reverse=True)
    total_prob = sum(p for _, p in symbols)
    probs = [p / total_prob for _, p in symbols]  # Нормализация, если требуется
    
    # Найти точку разделения
    cum_prob = 0.0
    split = 0
    min_diff = float('inf')
    for i in range(1, len(probs)):
        cum_prob += probs[i-1]
        diff = abs(cum_prob - (1 - cum_prob))
        if diff < min_diff:
            min_diff = diff
            split = i
    
    left = symbols[:split]
    right = symbols[split:]
    
    code = {}
    left_code = shannon_fano(left)
    for sym, c in left_code.items():
        code[sym] = '0' + c
    right_code = shannon_fano(right)
    for sym, c in right_code.items():
        code[sym] = '1' + c
    
    return code

def average_code_length(code: Dict[str, str], freq: Dict[str, int], total: int) -> float:
    """Рассчитать среднюю длину кода."""
    return sum(len(code[sym]) * (count / total) for sym, count in freq.items())

def encode_text(text: str, code: Dict[str, str], ngram_size: int) -> str:
    """Закодировать текст с использованием кода для n-грамм."""
    encoded = ''
    i = 0
    while i < len(text):
        if i + ngram_size > len(text):
            break  # Пропуск неполных n-грамм в конце для простоты
        ngram = text[i:i+ngram_size]
        if ngram in code:
            encoded += code[ngram]
        else:
            raise ValueError(f"Символ '{ngram}' отсутствует в коде")
        i += ngram_size
    return encoded

def decode_text(encoded: str, code: Dict[str, str]) -> str:
    """Декодировать с использованием кода (префиксный код)."""
    rev_code = {v: k for k, v in code.items()}
    decoded = ''
    current = ''
    for bit in encoded:
        current += bit
        if current in rev_code:
            decoded += rev_code[current]
            current = ''
    return decoded

def process_text(text: str, ignore_case=True, only_letters=True):
    """Предобработать текст."""
    if ignore_case:
        text = text.lower()
    if only_letters:
        text = ''.join(c for c in text if c.isalpha())
    return text

def read_text_from_file(filename: str) -> str:
    """Прочитать текст из файла."""
    try:
        with open(filename, 'r', encoding='utf-8') as file:
            return file.read()
    except FileNotFoundError:
        print(f"Файл '{filename}' не найден.")
        return ""
    except Exception as e:
        print(f"Ошибка при чтении файла: {e}")
        return ""

def main():
    # Чтение текста из файла
    text = read_text_from_file("DiskretMath/Sam2/text.txt")
    text = process_text(text)
    if not text:
        print("Пустой текст или ошибка чтения файла.")
        return
    
    # 1-граммы (отдельные буквы)
    print("Обработка 1-грамм (отдельных букв):")
    counter1 = collections.Counter(text)
    total1 = len(text)
    alphabet_size1 = len(counter1)
    
    # Энтропия
    entropy1 = calculate_entropy(counter1, total1)
    print(f"Энтропия на букву: {entropy1:.4f} бит")
    
    # Длина равномерного кода
    uniform_len1 = math.log2(alphabet_size1) if alphabet_size1 > 0 else 0
    print(f"Длина равномерного кода: {uniform_len1:.4f} бит")
    
    # Избыточность
    redundancy1 = uniform_len1 - entropy1
    print(f"Избыточность: {redundancy1:.4f} бит")
    
    # Вероятности
    probs1 = [(sym, count / total1) for sym, count in counter1.items()]
    
    # Код Шеннона-Фано
    code1 = shannon_fano(probs1)
    print("Коды Шеннона-Фано для 1-грамм:")
    for sym, c in sorted(code1.items(), key=lambda x: len(x[1])):
        print(f"{sym}: {c}")
    
    # Средняя длина кода
    avg_len1 = average_code_length(code1, counter1, total1)
    print(f"Средняя длина кода: {avg_len1:.4f} бит")
    
    # Эффективность сжатия (eta = H / L)
    efficiency1 = (entropy1 / avg_len1) * 100 if avg_len1 > 0 else 0
    print(f"Эффективность сжатия: {efficiency1:.2f}%")
    
    # Кодирование и декодирование
    encoded1 = encode_text(text, code1, 1)
    print(f"Закодированный текст (1-граммы): {encoded1[:100]}... (усечено)")
    decoded1 = decode_text(encoded1, code1)
    print(f"Декодированный текст совпадает с оригиналом: {decoded1 == text}")
    
    # 2-граммы (пары букв)
    print("\nОбработка 2-грамм (пар букв):")
    pairs = [text[i:i+2] for i in range(0, len(text)-1, 1)]  # Перекрывающиеся для статистики, но кодирование без перекрытия
    counter2 = collections.Counter(pairs)
    total2 = len(pairs)
    alphabet_size2 = len(counter2)
    
    # Энтропия для 2-грамм
    entropy2_bigram = calculate_entropy(counter2, total2)
    entropy_per_letter2 = entropy2_bigram / 2
    print(f"Энтропия биграмм: {entropy2_bigram:.4f} бит на биграмму")
    print(f"Энтропия на букву из биграмм: {entropy_per_letter2:.4f} бит")
    
    # Для равномерного кода: log2(M2) на биграмму
    uniform_len2 = math.log2(alphabet_size2) if alphabet_size2 > 0 else 0
    print(f"Длина равномерного кода на биграмму: {uniform_len2:.4f} бит")
    
    # Вероятности
    probs2 = [(sym, count / total2) for sym, count in counter2.items()]
    
    # Код Шеннона-Фано
    code2 = shannon_fano(probs2)
    print("Коды Шеннона-Фано для 2-грамм (первые 10):")
    for sym, c in sorted(code2.items(), key=lambda x: len(x[1]))[:10]:
        print(f"{sym}: {c}")
    print("... (полный список опущен)")
    
    # Средняя длина кода на биграмму
    avg_len2 = average_code_length(code2, counter2, total2)
    print(f"Средняя длина кода на биграмму: {avg_len2:.4f} бит")
    
    # Эффективность
    efficiency2 = (entropy2_bigram / avg_len2) * 100 if avg_len2 > 0 else 0
    print(f"Эффективность сжатия: {efficiency2:.2f}%")
    
    # Сравнение
    print("\nСравнение:")
    print(f"Средняя длина для 1-грамм: {avg_len1:.4f} бит на букву")
    print(f"Средняя длина для 2-грамм: {avg_len2 / 2:.4f} бит на букву (нормализованная)")
    print(f"Эффективность 1-грамм: {efficiency1:.2f}%")
    print(f"Эффективность 2-грамм: {efficiency2:.2f}% (для биграмм)")
    
    # Кодирование и декодирование для 2-грамм
    if len(text) % 2 != 0:
        text_for_encode2 = text[:-1]  # Усечение последней буквы
    else:
        text_for_encode2 = text
    encoded2 = encode_text(text_for_encode2, code2, 2)
    print(f"Закодированный текст (2-граммы): {encoded2[:100]}... (усечено)")
    decoded2 = decode_text(encoded2, code2)
    print(f"Декодированный текст совпадает с оригиналом (усечённым): {decoded2 == text_for_encode2}")

#Запуск!
if __name__ == "__main__":
    main()