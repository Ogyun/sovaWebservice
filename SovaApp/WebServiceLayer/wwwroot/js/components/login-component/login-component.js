define(["app","knockout","userService","tokenService"], function (app,ko,us,ts) {
    return function () {
        var email = ko.observable("");
        var password = ko.observable("");
        var loginSubmit = function () {
            us.login(email, password, function (response, status) {
                if (status == 200) {
                        app.navbarVisible(true);
                        ts.saveToken(response.token, response.email);
                        location.reload();
                    }
                   else if (status==400) {
                        alert("Incorrect credentials");
                    }
                    else {
                        console.log(response)
                        alert("something went wrong");
                    } 
            });
        }

        return {
            email,
            password,
            loginSubmit
        }
    }
    });