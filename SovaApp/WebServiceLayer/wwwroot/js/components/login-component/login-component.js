define(["knockout","loginService"], function (ko,ls) {
    return function () { 
        var email = ko.observable("");
        var password = ko.observable("");
        var loginSubmit = function () {
            ls.login(email, password, function (response) {
                localStorage.setItem('token', response.token)
            });
           
        }
        return {
            email,
            password,
            loginSubmit
        }
        }
        
    });