define(["knockout","userService","tokenService"], function (ko,us,ts) {
    return function () {
        var email = ko.observable("");
        var password = ko.observable("");
        var loginSubmit = function () {
            us.login(email, password, function (response) {
                ts.saveToken(response.token, response.email);
                location.reload();
            });
        }

        return {
            email,
            password,
            loginSubmit
        }
    }
    });