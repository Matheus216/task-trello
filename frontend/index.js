var idAtual = 1;
var idTask = 1;

initializer();

function initializer() {
    addPainel();
}
/*
    Funções dados Drag 
*/

function dragstart_handler(ev) {
    //Determina o efeito de arraste podendo ser copy / move / link
    ev.dataTransfer.setData('text/plain', ev.target.id);
    ev.dataTransfer.dropEffect = "move";
}

function dragover_handler(ev) {
    ev.preventDefault();

    //Define um dropEffect para ser do tipo move
    ev.dataTransfer.dropEffect = "move";
}

function drop_handler(ev, id) {
    ev.preventDefault();

    //Pega o id do alvo e adiciona o elemento que foi movido para o DOM do alvo

    var data = ev.dataTransfer.getData('text');
    let element = document.getElementById(`container-task_${id}`)

    element.appendChild(document.getElementById(data));
}

function dragent_handler(event) {
    var dragData = event.dataTransfer;
    console.log("mozUserCancelled = " + dragData.mozUserCancelled);
}


function addPainel() {
    let body = document.getElementById('painel')
    console.log(idAtual)

    for (let i = idAtual; i < (idAtual + 1); i++) {
        let painelHtml = `
            <div>
            <div class="painel" ondrop="drop_handler(event, ${i});" ondragover="dragover_handler(event)">
                <div class="header-painel">
                    <input value="A Fazer" />
                    <i class="fas fa-ellipsis-h" onclick="popupShow(${i})"></i>
                    <div id="poopup_${i}" class="pop-up" >
                    <div>
                        <h4>Ações</h4>
                        <i class="fas fa-times" onclick="closePop(${i})"></i>
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
                <div id="container-task_${i}" ondrop="drop_handler(event, ${i});" ondragover="dragover_handler(event)">
                    
                </div>
                <div class="footer-content">
                    <div class="footer-painel">
                        <i  class="fas fa-plus-circle icon-circle"></i>
                        <button class="btn-general" onClick="addTask(${i})" >Adicionar cartão</button>
                    </div>
                    <div class="icon-add">
                        <i class="fas fa-door-open"></i>
                    </div>
                </div>
            </div></div>`

        body.innerHTML += painelHtml;
    }

    idAtual++;
    console.log(idAtual)
    return false;
}

function popupShow(id) {
    let element = document.getElementById(`poopup_${id}`);

    if (element.style.display == 'none') {
        element.style.display = 'inline-block'
    } else {
        element.style.display = 'none'
    }
}

function closePop(id) {
    let element = document.getElementById(`poopup_${id}`);
    element.style.display = 'none'
}

function addTask(id) {
    let element = document.getElementById(`container-task_${id}`);

    element.innerHTML += `
    <canvas 
        id="task_${idTask}" 
        class="task-painel"  
        draggable="true" 
        ondragstart="dragstart_handler(event)";
        ondragend="dragent_handler(event)">
    </canvas>
    `;
    idTask++;
}