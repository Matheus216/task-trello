function post(dataPost, endpoint) {
    
    let data = JSON.stringify(dataPost);
    var responseRequest = null;

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: config.urlLocal + endpoint,
        data: data,
        async:false,
        success: function (response) {
            responseRequest = response; 
        }
    });

    return responseRequest;
}

function get(endpoint) {
    
    var responseRequest = null;

    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: `${config.urlLocal}${endpoint}`,
        async:false,
        success: function (response) {
            responseRequest = response; 
        }
    });

    return responseRequest;
}

function xdelete(endpoint) {
    var responseRequest = null;

    $.ajax({
        type: "DELETE",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: `${config.urlLocal}${endpoint}`,
        success: function (response) {
            responseRequest = response;
        }
    });

    return responseRequest;
}

function put(endpoint, dataPut){

    var responseRequest = null;
    let data = JSON.stringify(dataPut);

    $.ajax({
        type: "PUT",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: `${config.urlLocal}${endpoint}`,
        async: false,
        data: data,
        success: function (response) {
            responseRequest = response;
        },
        error: function (err) {
            responseRequest = err;
        }
    });

    return responseRequest; 
}
