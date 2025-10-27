document.addEventListener('DOMContentLoaded', function() {
    const tds = document.querySelectorAll('td')
    tds.forEach(el => {
        if (el.textContent.includes('(2,0)') || el.textContent.includes('(0,2)') || el.textContent.includes('(1,1)')) {
            el.style.backgroundColor = 'red';
        }
    })
})