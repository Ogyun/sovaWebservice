define(['knockout', 'store', 'questionService','noteService','tokenService'], function (ko, store, qs,ns,ts) {

    var question = ko.observable(store.getState().selectedQuestion);
    var answers = ko.observableArray([]);
    var email = ts.loadToken().email;
    var noteText = ko.observable("");
   
    qs.getQuestionAnswers(question().questionId, function (response) {
        answers(response);
    });

    return function () {


        store.subscribe(function () {
            var state = store.getState();
            question(state.selectedQuestion);
        });

        var saveNote = function () {
            ns.createNote(email, noteText(), question().questionId.toString(), function (response,status) {
                if (status == 201) {
                    alert("Note successfully created")
                    //clear noteText
                    noteText("");
                   //to do: update the noteList in note component
                } else {
                    alert("something went wrong")
                }

            });      
        };
    

        return {
            question,
            answers,
            noteText,
            saveNote
        };
    };
});