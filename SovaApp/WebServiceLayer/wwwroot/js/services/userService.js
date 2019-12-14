define(['app','tokenService'], function (app,ts) {

    var login = async function (email, password, callback) {

        var headers = new Headers();
        headers.append('Content-Type', 'application/json');

        var response = await fetch('http://localhost:5001/api/auth', {
            method: 'POST',
            body: JSON.stringify({ "email": email(), "password": password() }),
            headers: headers
        });
        var data = await response.json();
        callback(data,response.status);
    };

    var signup = async function (email, password, name, callback) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        var response = await fetch('http://localhost:5001/api/users', {
            method: 'POST',
            body: JSON.stringify({ "email": email(), "password": password(), "name": name() }),
            headers: headers
        });
        var data = await response.json();
        callback(data);
    };

    var update = async function (email, password, name, callback) {
        var headers = ts.loadToken().headers;
        var response = await fetch('http://localhost:5001/api/users', {
            method: 'PUT',
            body: JSON.stringify({ "email": email(), "password": password(), "name": name() }),
            headers: headers
        });
        var data = await response.json();
        callback(data, response.status);
    };
    return {
        login,
        update,
        signup
    };
});