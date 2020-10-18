

loadMember()
    .then(get)
    .then(response => constructMember(response)); 

function init() {
    searchPanel();
    $(".input-date").datepicker();
}

init();

// initializer(); 