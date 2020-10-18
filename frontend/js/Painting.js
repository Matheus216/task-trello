loadMember()
    .then(get)
    .then(response => constructMember(response)); 

function initializer() {
    searchPanel()
        .then(get)
        .then(x => {
            x.panel.map(panel => {
                appendHtmlPanel(panel);
            })
        });;

    $(".input-date").datepicker();
}

initializer();