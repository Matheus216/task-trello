

var urlLocal = "http://localhost:5000/api/";

function post(dataPost, endpoint) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: urlLocal + endpoint,
        data: dataPost,
        success: function (response) {
            return response; 
        }
    });
}

function get(endpoint) {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: urlLocal + endpoint,
        success: function (response) {
            return response;
        }
    });
}