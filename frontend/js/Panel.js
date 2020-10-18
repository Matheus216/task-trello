function searchPanel() {
    searchPanelPromise()
        .then(get)
        .then(x => {
            x.panel.map(panel => {
                appendHtmlPanel(panel);
            })
        });;
}

function searchPanelPromise() {
    document.getElementById("painel").innerHTML = '';

    return new Promise((resolve, reject) => {
        resolve("painting"); 
        reject("Falha para buscar os painéis"); 
    });
}

function addPanelPromise() {
    return new Promise((resolve, reject)=> {
        
        let data = {
            task: null,
            description: '',
            title: '',
            paintingId: 1
        };

        let endpoint = "Panel/Save";

        resolve(data, endpoint);
        reject();
    });
}
function addPanel() {
    addPanelPromise()
        .then(post)
        .then(panel => appendHtmlPanel(panel))
}

function deletePanel(id) {
    let endpoint = `panel/${id}`;

    xdelete(endpoint); 
    searchPanel();
}

function updatePanel(id) {
    let element = document.getElementById(`panel-${id}`);

    put(`panel/${id}/${element.value}`); 
}


function appendHtmlPanel(panel) {
    $(`#container-task_${panel.panelId}`).empty();

    document.getElementById("painel").innerHTML += `
    <div>
    <div class="painel" 
        ondrop="drop_handler(event, ${panel.panelId});" 
        ondragover="dragover_handler(event)">
        <div class="input-transform header-panel">
            <input value="${panel.title}" onChange="updatePanel(${panel.panelId})" 
            id="panel-${panel.panelId}" />
            <i class="fas fa-ellipsis-h" onclick="popupShow(${panel.panelId})"></i>
            <div id="poopup_${panel.panelId}" class="pop-up">
                <div>
                    <h4>Ações</h4>
                    <i class="fas fa-times"
                        style="cursor:pointer" 
                        onclick="closePop(${panel.panelId})"></i>
                </div>
                <hr />
                <ul>
                    <li>Adicionar cartão..</li>
                    <li>Copiar Lista..</li>
                    <li>Mover Lista..</li>
                    <li onclick="deletePanel(${panel.panelId})">Excluir painel..</li>
                </ul>
                <hr />
            </div>
        </div> 
        <div id="container-task_${panel.panelId}" 
            ondrop="drop_handler(event, ${panel.panelId});" 
            ondragover="dragover_handler(event)">
        </div>
        <div class="footer-content">
            <div class="footer-painel">
                <i class="fas fa-plus-circle icon-circle"></i>
                <button 
                    class="btn-general" 
                    onclick="addTaskModal(${panel.panelId})">
                        Adicionar cartão
                    </button>
            </div>
            <div class="icon-add">
                <i class="fas fa-door-open"></i>
            </div>
        </div>
    </div></div>`;


    panel.task.forEach(element => {
        searchTask(element, panel.panelId);
    });
}