define([], function () {
    var login = async function (email,password,callback) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
       var response = await fetch('http://localhost:5001/api/auth', {
            method: 'POST',
            body: JSON.stringify({"email":email(),"password":password()}),
            headers: headers
       });
        var data = await response.json();
        callback(data);
    };
    return {
        login
    };
});