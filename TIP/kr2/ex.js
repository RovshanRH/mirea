    document.addEventListener('DOMContentLoaded', function() {
    const divElement = document.querySelectorAll('div');
    const listElement = document.querySelectorAll('ul');
    const secondLiElement = document.querySelectorAll('li:nth-of-type(2)');
    // console.log(divElement, listElement, secondLiElement)
    divElement.forEach(element => {
        console.log(element);
    });
    listElement.forEach(element => {
        console.log(element);
    });
    secondLiElement.forEach(element => {
        console.log(element);
    });
})