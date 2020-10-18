function getCurrentDate() {
    let date = new Date();

    let day = date.getDay();
    let mounth = date.getMonth();
    let year = date.getFullYear();

    return `${day}/${mounth}/${year}`;
}

function ajustDate(date) {

    if (!date) {
        return '';
    }

    let a = date.substr(0, 10).split('-');
    let day = a[2];
    let mounth = a[1];
    let year = a[0];

    return `${day}/${mounth}/${year}`;
}