﻿define([], function () {

    var token = localStorage.getItem('token');
    var headers = new Headers();
    headers.append('Authorization', 'Bearer ' + token);


    var getNotesByUserEmail = async function (email, callback) {
        var response = await fetch("http://localhost:5001/api/notes/" + email, {
            method: 'GET',
            headers: headers
        });
        var data = await response.json();
        callback(data);
    }

    var getAllNotesForQuestion = = async function (email,questionId, callback) {
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
        callback(data);
    }

    var deleteSpecificNote = async function (noteId, callback) {
        var response = await fetch("http://localhost:5001/api/notes/"+noteId, {
            method: 'DELETE',
            headers: headers
        });
        var data = await response;
        callback(data);
    }

    var updateNote = async function (note, callback) {
        var response = await fetch("http://localhost:5001/api/notes/" + note.id, {
            method: 'PUT',
            headers: headers,
            body: JSON.stringify({ "Id":note.id, "UserEmail": note.email, "NoteText": note.noteText, "QuestionId": note.questionId })
        });
        var data = await response.json();
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