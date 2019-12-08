define([], function () {

    var authUser = async function (callback) {
        var response = await fetch("http://localhost:5001/api/auth")
        var data = await response.json();
        callback(data);
        }

    return {
    authUser
    };
});