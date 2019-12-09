define(["knockout", "signupService"], function (ko, su) {
    return function () {
        var email = ko.observable("");
        var password = ko.observable("");
        var name = ko.observable("");
        var signupSubmit = function () {
            su.signup(email, password, name, function (response) {
                console.log(response)
            });

        }
        return {
            email,
            password,
            name,
            signupSubmit
        }
    }

});