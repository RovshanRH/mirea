document.addEventListener('DOMContentLoaded', function () {
    const age_table = this.getElementById('age-table')
    // const table = this.querySelectorAll('table')
    const labels = age_table.querySelectorAll('label')
    const age = this.querySelectorAll('td')[0]
    const search = this.querySelectorAll('form[name="search"]')
    const search1 = search[0][search.length-1]
    const search_last = search[0][1]
    // console.log(search_last, search1)
    console.log(age_table, labels, age, search1, search_last)

})