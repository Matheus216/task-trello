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
        var data = ev.dataTransfer.getData("text");
        var element = document.getElementById(`container-task_${id}`);
        element.appendChild(document.getElementById(data));

        let element = document.getElementById(ev.target.id);

        let data = {
            panelId: id,
            taskId: ev.target.id
        }
       
        $.ajax({
            type: "PUT",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: config.urlLocal + "task",
            data: JSON.stringify(data)
        });
    },

    dragent_handler: function (event) {
        var dragData = event.dataTransfer;
    },

    searchPanel: function () {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: config.urlLocal + "painting",
            success: function (response) {
                var panel = response.panel;
                for (let i = 0; i < panel.length; i++) {
                    $(`#container-task_${panel[i].panelId}`).empty();

                    document.getElementById("painel").innerHTML += `
                    <div>
                    <div class="painel" 
                        ondrop="window.PaintingService.drop_handler(event, ${panel[i].panelId});" 
                        ondragover="window.PaintingService.dragover_handler(event)">
                        <div class="input-transform header-panel">
                            <input value="A Fazer" />
                            <i class="fas fa-ellipsis-h" onclick="window.PaintingService.popupShow(${panel[i].panelId})"></i>
                            <div id="poopup_${panel[i].panelId}" class="pop-up">
                                <div>
                                    <h4>Ações</h4>
                                    <i class="fas fa-times" 
                                        onclick="window.PaintingService.closePop(${panel[i].panelId})"></i>
                                </div>
                                <hr />
                                <ul>
                                    <li>Adicionar cartão..</li>
                                    <li>Copiar Lista..</li>
                                    <li>Mover Lista..</li>
                                    <li>Seguir..</li>
                                </ul>
                                <hr />
                            </div>
                        </div>
                        <div id="container-task_${panel[i].panelId}" 
                            ondrop="window.PaintingService.drop_handler(event, ${panel[i].panelId});" 
                            ondragover="window.PaintingService.dragover_handler(event)">
                        </div>
                        <div class="footer-content">
                            <div class="footer-painel">
                                <i class="fas fa-plus-circle icon-circle"></i>
                                <button class="btn-general" 
                                    onClick="window.PaintingService.addTask(${panel[i].panelId})" >Adicionar cartão</button>
                            </div>
                            <div class="icon-add">
                                <i class="fas fa-door-open"></i>
                            </div>
                        </div>
                    </div></div>`;


                    panel[i].task.forEach(element => {
                        window.PaintingService.searchTask(element.taskId, panel[i].panelId); 
                    });
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
                window.PaintingService.searchPanel();
            }
        });
        return false;
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

    searchTask: function (taskId, panelId) {
        var element = document.getElementById(`container-task_${panelId}`);
        element.innerHTML += `
        <canvas 
            id="task_${taskId}" 
            class="task-painel"  
            draggable="true" 
            ondragstart="window.PaintingService.dragstart_handler(event)";
            ondragend="window.PaintingService.dragent_handler(event)">
        </canvas>`;
    },

    addTask: function(panelId){
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
                window.PaintingService.searchPanel();
            }
        });
    }
};

window.PaintingService.initializer(); 