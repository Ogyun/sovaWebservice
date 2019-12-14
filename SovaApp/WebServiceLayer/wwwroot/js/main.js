require.config({
    baseUrl: "js",
    paths: {
        jquery: "../lib/jquery/dist/jquery",
        jqcloud: "../lib/jqcloud2/dist/jqcloud",
        knockout: "../lib/knockout/build/output/knockout-latest.debug",
        text: "../lib/requirejs-text/text",
        searchService: "services/searchService",
        signupService: "services/signupService",
        markingService: "services/markingService",
        noteService: "services/noteService",
        questionService:"services/questionService",
        store: "services/store",
        tokenService: "services/tokenService",
        userService:"services/userService"

    },
    shim: {
        jqcloud: ["jquery"]
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
    ko.components.register('word_cloud-component', {
        viewModel: { require: "components/word_cloud-component/word_cloud" },
        template: { require: "text!components/word_cloud-component/word_cloud.html" }
    });
});

require(["knockout","store", "app"], function (ko,store,app) {
    //console.log(app.name);
    store.subscribe(() => console.log(store.getState()));
    ko.applyBindings(app);
});