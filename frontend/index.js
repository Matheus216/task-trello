function addPainel() {
    let body = document.getElementById('content-body')

    body.removeChild(document.getElementById('externo'))

    let painelHtml = `
    <div class="painel">
        <div class="header-painel">
            <input value="A Fazer" />
            <i class="fas fa-ellipsis-h" onclick="popupShow()"></i>
            <div id="poopup" class="pop-up" >
            <div>
                <h4>Ações</h4>
                <i class="fas fa-times"></i>
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
        <canvas class="task-painel">
        </canvas>
        <canvas class="task-painel">
        </canvas>
        <div class="footer-content">
            <div class="footer-painel">
                <i  class="fas fa-plus-circle icon-circle"></i>
                <button class="btn-general">Adicionar cartão</button>
            </div>
            <div class="icon-add">
                <i class="fas fa-door-open"></i>
            </div>
        </div>
    </div>
    <div id="externo">
    <div class="btn-externo" onclick="addPainel()">
            <i class="fas fa-plus-circle icon-circle"></i>
            <button class="btn-general" >Adicionar painel</button>
        </div>
    </div>`

    body.innerHTML += painelHtml;

    return false;
}

function popupShow() {
    let element = document.getElementById('poopup');

    if (element.style.display == 'none') {
        element.style.display = 'inline-block'
    } else {
        element.style.display = 'none'
    }
}