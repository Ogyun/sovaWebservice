define(["knockout"], function (ko) {
    var currentComponent = ko.observable("login-component");
    var changeComponent = () => {
        if (currentComponent() === "login-component") {
            currentComponent("signup-component");
        } else {
            currentComponent("login-component");
        }
    };
    return {
        currentComponent,
        changeComponent
    };
});