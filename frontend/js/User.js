function loadMember() {
    return new Promise((resolve, reject) => {
        resolve('user');
    });
}

function requestMember() {
    let xhttp = new XMLHttpRequest();
    let url = `${urlLocal}User`;

    xhttp.open('GET', url, false);
    xhttp.send();

    return JSON.parse(xhttp.response);
}

function constructMember(data) {
    let elementUL = document.getElementById('member-list');

    data.map(x => {
        let li = document.createElement('li');

        li.id = x.userId;
        li.innerHTML = `${x.name}: ${x.age}`;

        elementUL.appendChild(li);
    });
}
