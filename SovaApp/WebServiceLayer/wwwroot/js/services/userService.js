define(['app','tokenService'], function (app,ts) {

    var login = async function (email, password, callback) {

        var headers = new Headers();
        headers.append('Content-Type', 'application/json');

        var request = await fetch('http://localhost:5001/api/auth', {
            method: 'POST',
            body: JSON.stringify({ "email": email(), "password": password() }),
            headers: headers
        }).then(function (response) {
            if (response.status == 200) {
                app.navbarVisible(true);
            }
            else {
                alert("Incorrect credentials");
            }
            return response;
        });
        var data = await request.json();
        callback(data);
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
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        var response = await fetch('http://localhost:5001/api/users', {
            method: 'UPDATE',
            body: JSON.stringify({ "email": email(), "password": password(), "name": name() }),
            headers: headers
        });
        var data = await response.json();
        callback(data);
    };
    return {
        login,
        update,
        signup
    };
});