define(['knockout', 'store'], function (ko, store) {

    var question = ko.observable(store.getState().selectedQuestion);

    return function () {
     
        console.log(question().body);

        store.subscribe(function () {
            var state = store.getState();
            question(state.selectedQuestion);
        });

        return {
            question
        };
    };
});