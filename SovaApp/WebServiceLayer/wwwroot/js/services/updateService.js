define([], function () {
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
        update
    };
});