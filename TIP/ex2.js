number_1 = prompt("Число: ")
alert(`Неортицательное? ${number_1 >= 0}`)
number_2 = prompt("Ещё число: ")
alert(`Чётное? ${number_2%2===0}`)

console.log(`Делится первое на второе без остатка? ${parseInt(number_1)%parseInt(number_2)===0}`)

num_1 = +prompt("Первое число:")
oper = prompt("Операнд:")
num_2 = +prompt("Второе число:")
switch (oper) {
    case "+":
        alert(num_1+num_2)
        break
    case "-":
        alert(num_1 - num_2)
        break
    case "/":
        alert(num_1 / num_2)
        break
    case "*":
        alert(num_1*num_2)
        break
    default:
        alert("Неправильный оператор")
        break
}

summ = +(prompt("Общая сумма счёта: "))
procent = +prompt("Процент чаевых: ")
summ_procent = summ * (procent/100)
alert(summ+procent)

max = +prompt("max")
min = +prompt("min")
alert(`${Math.floor(Math.random() * max + Math.random() * min)}`)
