define(['knockout', 'noteService','tokenService'], function (ko, ns,ts) {

    var userEmail = ts.loadToken().email;
    var noteList = ko.observableArray([]);

    //Get all Notes for specific user
    ns.getNotesByUserEmail(userEmail, function (response) {
     
        noteList(response.items);
    });

    return function () {

        var onNoteClick = function (note) {
            //Do something
            console.log(note)
           
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


        return {
            noteList,
            onNoteClick,
            deleteSpecificNote,
            
        };
    }


});