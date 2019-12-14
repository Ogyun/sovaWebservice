define(["knockout", "userService"], function (ko, su) {
    return function () {
        var email = ko.observable("");
        var password = ko.observable("");
        var name = ko.observable("");
        var rpassword = ko.observable("");
        var signupSubmit = function () {
            if (password() === rpassword()) {
                su.signup(email, password, name, function (response) {
                    console.log(response)
                });
            }
            else alert("Passwords do not match!");
        }
        return {
            email,
            password,
            name,
            rpassword,
            signupSubmit
        }
    }

});