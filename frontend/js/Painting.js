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
                    let painelHtml = `
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
                    </div></div>`
                    document.getElementById("painel").innerHTML += painelHtml;
                }
            }
        });
    },

    addPanel: function () {
        var body = document.getElementById("painel");
        for (let i = config.idAtual; i < (config.idAtual + 1); i++) {
            let painelHtml = `
            <div>
            <div class="painel" ondrop="window.PaintingService.drop_handler(event, ${i});" ondragover="window.PaintingService.dragover_handler(event)">
                <div class="input-transform header-panel">
                    <input value="A Fazer" />
                    <i class="fas fa-ellipsis-h" onclick="window.PaintingService.popupShow(${i})"></i>
                    <div id="poopup_${i}" class="pop-up">
                        <div>
                            <h4>Ações</h4>
                            <i class="fas fa-times" onclick="window.PaintingService.closePop(${i})"></i>
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
                <div id="container-task_${i}" ondrop="window.PaintingService.drop_handler(event, ${i});" ondragover="window.PaintingService.dragover_handler(event)">
        
                </div>
                <div class="footer-content">
                    <div class="footer-painel">
                        <i class="fas fa-plus-circle icon-circle"></i>
                        <button class="btn-general" onClick="window.PaintingService.addTask(${i})" data-toggle="modal" data-target="#modal-main">Adicionar cartão</button>
                    </div>
                    <div class="icon-add">
                        <i class="fas fa-door-open"></i>
                    </div>
                </div>
            </div>
        </div>`

            body.innerHTML += painelHtml;
        }

        config.idAtual++;
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
    
    addTask: function (id) {
        var element = document.getElementById(`container-task_${id}`);
        element.innerHTML += `
        <canvas 
            id="task_${config.idTask}" 
            class="task-painel"  
            draggable="true" 
            ondragstart="window.PaintingService.dragstart_handler(event)";
            ondragend="window.PaintingService.dragent_handler(event)">
        </canvas>`;
        config.idTask++;
    }
};
window.PaintingService.initializer(); 