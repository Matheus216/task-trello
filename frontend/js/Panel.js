function searchPanel() {
    searchPanelPromise()
        .then(response => {
            response.panel.map(panel => {
                appendHtmlPanel(panel);
            })
        });;
}

function searchPanelPromise() {
    return new Promise((resolve, reject) => {
        document.getElementById("painel").innerHTML = '';

        var response = get("painting");

        resolve(response); 
        reject("Falha para buscar os painéis"); 
    });
}

function addPanel() {
    addPanelPromise()   
        .then(panel => appendHtmlPanel(panel))
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

        let response = post(data, endpoint);

        resolve(response);
        reject();
    });
}

function deletePanel(id) {
    $('#loader1').show();
    deletePanelPromise(id)
        .then(response => {
            $('#loader1').hide();
            searchPanel() 
        })
        .catch(err =>  { 
            $('#loader1').hide();
            console.log(err)
        });
}

function deletePanelPromise(id) {
    return new Promise((resolve, reject) => { 
        let response = xdelete(`panel/${id}`);

        resolve(response);
        reject();
    });
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