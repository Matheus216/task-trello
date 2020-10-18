function dragstart_handler(ev) {
    ev.dataTransfer.setData("text/plain", ev.target.id);
    ev.dataTransfer.dropEffect = "move";
}

function dragover_handler(ev) {
    ev.preventDefault();
    ev.dataTransfer.dropEffect = "move";
}

function drop_handler(ev, id) {
    ev.preventDefault();
    let data = ev.dataTransfer.getData("text");
    let element = document.getElementById(`container-task_${id}`);
    element.appendChild(document.getElementById(data));

    var regex = new RegExp('[0-9]{1,}');

    let dataTrasfer = {
        panelId: id,
        taskId: parseInt(regex.exec(data)[0])
    }

    put('task', dataTrasfer);
}