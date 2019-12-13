define([], function () {

    var saveToken = function (token, email) {
        localStorage.setItem('token', token);
        localStorage.setItem('email', email);
    }

    var loadToken = function () {

        var token = localStorage.getItem('token');
        var email = localStorage.getItem('email');
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        headers.append('Authorization', 'Bearer ' + token);


        return {
            "email": email,
            "headers": headers
        }
    }
 
    return {
        saveToken,
        loadToken

    };
});