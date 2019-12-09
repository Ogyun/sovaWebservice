require.config({
    baseUrl: "js",
    paths: {
        knockout: "../lib/knockout/build/output/knockout-latest.debug",
        text: "../lib/requirejs-text/text",
        searchService: "services/searchService",
        loginService: "services/loginService",
        signupService: "services/signupService"

    }
});

require(["knockout"], function (ko) {
    ko.components.register('search-component', {
        viewModel: { require: "components/search-component/search-component" },
        template: { require: "text!components/search-component/search-component.html" }
    });
    ko.components.register('login-component', {
        viewModel: { require: "components/login-component/login-component" },
        template: { require: "text!components/login-component/login-component.html" }
    });
    ko.components.register('signup-component', {
        viewModel: { require: "components/signup-component/signup-component" },
        template: { require: "text!components/signup-component/signup-component.html" }
    });
});

require(["knockout", "app"], function (ko, app) {
    //console.log(app.name);

    ko.applyBindings(app);
});