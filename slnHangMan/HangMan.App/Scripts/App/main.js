function PostRequest(_uri, _JSonData, onSuccess, onError, _async) {
    $.ajax({
        type: "POST",
        url: _uri,
        async: _async,
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        data: _JSonData,
        success: function (result) {
            onSuccess(result);
        },
        error: function (errorThrown) {
            onError(errorThrown);
        }
    });
}

function ReturnRequest(_uri, onSuccess, onError, _async, _method) {
    var returnValue = null;
    $.ajax({
        type: _method,
        url: _uri,
        async: _async,
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        success: function (result) {
            returnValue = result;
            onSuccess(result);
        },
        error: function (errorThrown) {
            onError(errorThrown);
        }
    });

    return returnValue;

}


function Request(_uri, onSuccess, onError, _async,_method) {
    $.ajax({
        type: _method,
        url: _uri,
        async: _async,
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        success: function (result) {
            onSuccess(result);
        },
        error: function (errorThrown) {
            onError(errorThrown);
        }
    });

}
