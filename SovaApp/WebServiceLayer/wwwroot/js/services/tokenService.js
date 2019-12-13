define([], function () {

    var saveToken = function (token, email) {
        localStorage.setItem('token', token);
        localStorage.setItem('email', email);
    }

    var loadToken = function () {

        var token = localStorage.getItem('token');
        var email = localStorage.getItem('email');
        var headers = new Headers();
        headers.append('Authorization', 'Bearer ' + token);

        return {
            "email": email,
            "headers": headers
        }
    }

    var checkToken = function () {
        var token = localStorage.getItem('token');
        if (token !== null) {
            return true
        }
        else return false
    }

    var deleteToken = function () {
        localStorage.clear();
    }

    return {
        saveToken,
        loadToken,
        checkToken,
        deleteToken
    };
});