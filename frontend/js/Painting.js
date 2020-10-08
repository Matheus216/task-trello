var config = {
    idAtual: 1,
    idTask: 1,
    urlLocal: "http://localhost:5000/api/"
};

window.PaintingService = {
    initializer: function () {
        window.PaintingService.searchPanel();
        $(".input-date").datepicker();
    },

    dragstart_handler: function (ev) {
        ev.dataTransfer.setData("text/plain", ev.target.id);
        ev.dataTransfer.dropEffect = "move";

    },

    dragover_handler: function (ev) {
        ev.preventDefault();
        ev.dataTransfer.dropEffect = "move";
    },

    drop_handler: function (ev, id) {
        ev.preventDefault();
        let data = ev.dataTransfer.getData("text");
        let element = document.getElementById(`container-task_${id}`);
        element.appendChild(document.getElementById(data));

        var regex = new RegExp('[0-9]{1,}');

        let dataTrasfer = {
            panelId: id,
            taskId: parseInt(regex.exec(data)[0])
        }

        $.ajax({
            type: "PUT",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: config.urlLocal + "task",
            data: JSON.stringify(dataTrasfer)
        });
    },

    dragent_handler: function (event) {
        var dragData = event.dataTransfer;
    },

    searchPanel: function () {
        $("#painel").empty();

        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: config.urlLocal + "painting",
            success: function (response) {
                var panel = response.panel;
                for (let i = 0; i < panel.length; i++) {
                    window.PaintingService.appendHtmlPanel(panel[i]);
                }
            }
        });
    },

    addPanel: function () {

        let data = {
            task: null,
            description: '',
            title: '',
            paintingId: 1
        };
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: config.urlLocal + "panel/save",
            data: JSON.stringify(data),
            success: function (response) {
                window.PaintingService.appendHtmlPanel(response);
            }
        });

        return false;
    },

    appendHtmlPanel: function (panel) {
        $(`#container-task_${panel.panelId}`).empty();

        document.getElementById("painel").innerHTML += `
        <div>
        <div class="painel" 
            ondrop="window.PaintingService.drop_handler(event, ${panel.panelId});" 
            ondragover="window.PaintingService.dragover_handler(event)">
            <div class="input-transform header-panel">
                <input value="${panel.title}" onChange="window.PaintingService.updatePanel(${panel.panelId})" />
                <i class="fas fa-ellipsis-h" onclick="window.PaintingService.popupShow(${panel.panelId})"></i>
                <div id="poopup_${panel.panelId}" class="pop-up">
                    <div>
                        <h4>Ações</h4>
                        <i class="fas fa-times"
                            style="cursor:pointer" 
                            onclick="window.PaintingService.closePop(${panel.panelId})"></i>
                    </div>
                    <hr />
                    <ul>
                        <li>Adicionar cartão..</li>
                        <li>Copiar Lista..</li>
                        <li>Mover Lista..</li>
                        <li onclick="window.PaintingService.deletePanel(${panel.panelId})">Excluir painel..</li>
                    </ul>
                    <hr />
                </div>
            </div>
            <div id="container-task_${panel.panelId}" 
                ondrop="window.PaintingService.drop_handler(event, ${panel.panelId});" 
                ondragover="window.PaintingService.dragover_handler(event)">
            </div>
            <div class="footer-content">
                <div class="footer-painel">
                    <i class="fas fa-plus-circle icon-circle"></i>
                    <button class="btn-general" 
                        onClick="window.PaintingService.addTask(${panel.panelId})" >Adicionar cartão</button>
                </div>
                <div class="icon-add">
                    <i class="fas fa-door-open"></i>
                </div>
            </div>
        </div></div>`;


        panel.task.forEach(element => {
            window.PaintingService.searchTask(element, panel.panelId);
        });
    },

    popupShow: function (id) {
        var element = document.getElementById(`poopup_${id}`);
        if (element.style.display == "none") {
            element.style.display = "inline-block"
        } else {
            element.style.display = "none"
        }
    },

    closePop: function (id) {
        var element = document.getElementById(`poopup_${id}`);
        element.style.display = "none";
    },

    searchTask: function (task, panelId) {
        
        let element = document.getElementById(`container-task_${panelId}`);
        let date = ajustDate(task.dateFinished); 

        element.innerHTML += `
        <div 
            id="task_${task.taskId}" 
            class="task-painel"  
            draggable="true" 
            ondragstart="window.PaintingService.dragstart_handler(event)";
            ondragend="window.PaintingService.dragent_handler(event)">
            <div class="cabecalho-task"></div>
            <div class="content-task-header">
                <label for="">${task.description}</label>
                <i class="fas fa-cog"></i>
            </div>
                <div class="content-task-body">
                <label for="" id="fast-date-label-${task.taskId}">
                    ${date == '' ? getCurrentDate() : date }
                </label>
            </div>
            <div class="avatar"></div>
        </div>`;
    },

    addTask: function (panelId) {
        let data = {
            description: '',
            title: '',
            status: 0,
            dateBegin: null,
            dateFinished: null,
            estimated: '',
            panelId: panelId,
            title: '',
            user: null,
            checkList: null
        };

        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: config.urlLocal + "task/save",
            data: JSON.stringify(data),
            success: function (response) {
                window.PaintingService.searchTask(response, panelId);
            }
        });
    },

    deletePanel: function (id) {
        $.ajax({
            type: "DELETE",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: `${config.urlLocal}panel/${id}`,
            success: function (response) {
                window.PaintingService.searchPanel();
            }
        });
    }
};

function getCurrentDate(){
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

window.PaintingService.initializer(); 