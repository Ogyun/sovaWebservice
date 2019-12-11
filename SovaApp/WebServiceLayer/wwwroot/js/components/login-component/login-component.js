define(["knockout","loginService","tokenService"], function (ko,ls,ts) {
    return function () { 
        var email = ko.observable("");
        var password = ko.observable("");
        var loginSubmit = function () {
            ls.login(email, password, function (response) {
                ts.saveToken(response.token, response.email);
            });
           
        }
        return {
            email,
            password,
            loginSubmit
        }
        }
        
    });