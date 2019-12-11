require.config({
    baseUrl: "js",
    paths: {
        knockout: "../lib/knockout/build/output/knockout-latest.debug",
        text: "../lib/requirejs-text/text",
        searchService: "services/searchService",
        loginService: "services/loginService",
        signupService: "services/signupService",
        markingService: "services/markingService",
        noteService: "services/noteService",
        questionService:"servicess/questionService",
        updateService: "services/updateService"

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
    ko.components.register('userinfo-component', {
        viewModel: { require: "components/userinfo-component/userinfo-component" },
        template: { require: "text!components/userinfo-component/userinfo-component.html" }
    });
    ko.components.register('search_history-component', {
        viewModel: { require: "components/search_history-component/search_history" },
        template: { require: "text!components/search_history-component/search_history.html" }
    });
    ko.components.register('marked_questions-component', {
        viewModel: { require: "components/marked_questions-component/marked_questions" },
        template: { require: "text!components/marked_questions-component/marked_questions.html" }
    });
    ko.components.register('question-component', {
        viewModel: { require: "components/question-component/question-component" },
        template: { require: "text!components/question-component/question-component.html" }
    });
    ko.components.register('note-component', {
        viewModel: { require: "components/note-component/note-component" },
        template: { require: "text!components/note-component/note-component.html" }
    });
});

require(["knockout", "app"], function (ko, app) {
    //console.log(app.name);

    ko.applyBindings(app);
});