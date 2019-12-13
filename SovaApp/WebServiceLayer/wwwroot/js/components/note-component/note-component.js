define(['knockout', 'noteService','tokenService'], function (ko, ns,ts) {

    var userEmail = ts.loadToken().email;
    var noteList = ko.observableArray([]);
    var noteObject = ko.observable();
    var noteText = ko.observable();

    //Get all Notes for specific user
    ns.getNotesByUserEmail(userEmail, function (response) {
     
        noteList(response.items);
    });

    return function () {

        var onNoteClick = function (note) {
            noteObject(note);
            noteText(note.notetext);
        };

        var deleteSpecificNote = function (note) {
            ns.deleteSpecificNote(note.link, function (response) {
                if (response.status == 200) {
                    noteList.remove(note)
                } else {
                    alert("something went wrong");
                }
            });
        }

        var updateNote = function () {
            noteObject().notetext = noteText();
            ns.updateNote(noteObject(), function (response) {
                if (response.status==200) {
                    noteText("");
                    noteObject({});
                    alert("Note is successfully updated");

                    //Get all Notes in order to display the updated note
                    ns.getNotesByUserEmail(userEmail, function (response) {

                        noteList(response.items);
                    });

                } else {
                    alert("Something went wrong");
                }
            });
        }


        return {
            noteList,
            onNoteClick,
            deleteSpecificNote,
            noteObject,
            updateNote,
            noteText
        };
    }


});