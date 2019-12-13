define(["knockout", "updateService","tokenService"], function (ko, su, ts) {
    return function () {
        var email = ko.observable(localStorage.getItem("email"));
        var password = ko.observable("");
        var name = ko.observable(localStorage.getItem("name"));
        var rpassword = ko.observable("");
        var update = function () {
            if (password() === rpassword()) {
                su.update(email, password, name, function (response) {
                    console.log(response)
                });
            }
            else alert("Passwords do not match!");
        }
        var logout = function () {
            ts.deleteToken();
            location.reload();
        }
        return {
            email,
            password,
            name,
            rpassword,
            update,
            logout
        }
    }

});