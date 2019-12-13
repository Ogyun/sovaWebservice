define(["tokenService"], function (ts) {

    var headers = ts.loadToken().headers;


    var getNotesByUserEmail = async function (email, callback) {
        var response = await fetch("http://localhost:5001/api/notes/" + email, {
            method: 'GET',
            headers: headers
        });
        var data = await response.json();
        callback(data);
    }

    var getAllNotesForQuestion = async function (email,questionId, callback) {
        var response = await fetch("http://localhost:5001/api/notes/"+ email +"/question/"+questionId, {
            method: 'GET',
            headers: headers
        });
        var data = await response.json();
        callback(data);
    }

    var getSpecificNote = async function (email, noteId, callback) {
        var response = await fetch("http://localhost:5001/api/notes/" + email + "/" + noteId, {
            method: 'GET',
            headers: headers
        });
        var data = await response.json();
        callback(data);
    }
    var createNote = async function (email,noteText, questionId, callback) {
        var response = await fetch("http://localhost:5001/api/notes/", {
            method: 'POST',
            headers: headers,
            body: JSON.stringify({ "UserEmail": email, "NoteText": noteText, "QuestionId": questionId })
        });

        var data = await response.json();
        //include response status
        callback(data,response.status);
    }

    var deleteSpecificNote = async function (noteLink, callback) {
        var response = await fetch(noteLink, {
            method: 'DELETE',
            headers: headers
        });
        var data = await response;
        callback(data);
    }

    var updateNote = async function (note, callback) {
        var response = await fetch(note.link, {
            method: 'PUT',
            headers: headers,
            body: JSON.stringify({"UserEmail": "", "NoteText": note.notetext, "QuestionId": note.questionId })
        });
        var data = await response;
        callback(data);
    }

    return {
        getNotesByUserEmail,
        getAllNotesForQuestion,
        getSpecificNote,
        createNote,
        deleteSpecificNote,
        updateNote
    };
});