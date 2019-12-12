define(['knockout', 'store', 'questionService'], function (ko, store, qs) {

    var question = ko.observable(store.getState().selectedQuestion);
    var answers = ko.observableArray([]);
   
    qs.getQuestionAnswers(question().questionId, function (response) {
        answers(response);
    });

    return function () {
    

        store.subscribe(function () {
            var state = store.getState();
            question(state.selectedQuestion);
        });

        return {
            question,
            answers
        };
    };
});