function addTask(panelId) {
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

    searchTask(post(data), panelId);
}

function openTask(taskId) {
    let element = document.getElementById('modal-01');
    let myTemplate = $.templates('#modalUpdate');

    let response = get(`Task/${taskId}`); 

    let modalData = {
        title: response.title,
        description: response.description,
        dateBegin: ajustDate(response.dateBegin),
        dateFinished: ajustDate(response.dateFinished),
        taskId: response.taskId,
        panelId: response.panelId,
        estimated: response.estimated
    }
    
    element.innerHTML = myTemplate.render(modalData);
    $('#modal-main').modal('show');
}

function addTaskModal() {
    let element = document.getElementById('modal-01');
    let myTemplate = $.templates('#modalCreated');

    element.innerHTML = myTemplate.render();
    $('#modal-main').modal('show');
}

function saveTask(id, panelId){

    let data = {
        taskId: id == null || id == undefined ? 0 : id,
        description: $('#message-text').val(),
        dateBegin: new Date($('#dateBegin').val()),
        dateFinished: $('#dateFinished').val() == undefined ? null : new Date($('#dateFinished').val()),
        estimated: $('#estimated').val(),
        panelId: panelId,
        title: $('#title-task').val()
    }

    post(data, 'Task/Save');
}

function searchTask(task, panelId) {

    let element = document.getElementById(`container-task_${panelId}`);
    let title = task.description;
    let date = ajustDate(task.dateFinished);

    if (title && title.length > 26) {
        title = task.description.substr(0, 26);
    }

    element.innerHTML += `
    <div 
        onclick="openTask(${task.taskId})"
        id="task_${task.taskId}" 
        class="task-painel"  
        draggable="true" 
        ondragstart="dragstart_handler(event)">
        <div class="cabecalho-task"></div>
        <div class="content-task-header">
            <label for="">${title}</label>
            <i class="fas fa-cog"></i>
        </div>
        <div class="content-task-body">
            <div class="label-date">
                <label for="" id="fast-date-label-${task.taskId}">
                    ${date == '' ? getCurrentDate() : date}
                </label>
            </div>
            <div class="avatar"></div>
        </div>
    </div>`;
}