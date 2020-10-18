function popupShow(id) {
    var element = document.getElementById(`poopup_${id}`);
    if (element.style.display == "none") {
        element.style.display = "inline-block"
    } else {
        element.style.display = "none"
    }
}

function closePop(id) {
    var element = document.getElementById(`poopup_${id}`);
    element.style.display = "none";
}
