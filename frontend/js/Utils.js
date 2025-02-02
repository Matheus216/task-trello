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

    return `${mounth}/${day}/${year}`;
}

function convertFormatDate(str) {

    if (!str || str == undefined) {
        return null; 
    }

    let date = str.substr(0, 10).split('/');
    let day = date[1];
    let mounth = date[0];
    let year = date[2];

    return `${year}-${mounth}-${day}`; 
}

function notification(type, message, emphasis = "Sucesso") { 
    
    var html = `        
            <div  class="alert alert-dismissible fade alert-${type} show" role="alert" >
                <strong>${emphasis}!</strong><div id="message">${message}</div>
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
                </button>
            </div>`; 
    
    var not = document.getElementById('modalNotification');

    not.innerHTML += html; 
} 