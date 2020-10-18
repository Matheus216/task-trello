function loadMemberPromise() {
    return new Promise((resolve, reject) => {
        resolve('user');
    });
}

function constructMember(data) {
    let select = document.getElementById('member-list');

    data.map(x => {
        let option = document.createElement('option');

        option.id = x.userId;
        option.value = x.userId;
        option.innerHTML = `${x.name}`;

        select.appendChild(option);
    });
}

function loadMember() {
    loadMemberPromise()
        .then(get)
        .then(response => constructMember(response));
}
