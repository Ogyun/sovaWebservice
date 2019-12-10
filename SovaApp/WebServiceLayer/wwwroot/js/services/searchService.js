﻿define([], function () {

    var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im9neXVuQGdtYWlsLmNvbSIsIm5iZiI6MTU3NTk3NzkxMCwiZXhwIjoxNTc1OTg4NzEwLCJpYXQiOjE1NzU5Nzc5MTB9.h6abxYh0oIz8PsXWspOcnVXhep-js6cA1kzYU-eS-LM";
    var headers = new Headers();
    headers.append('Authorization','Bearer ' + token);


    var searchByKeyword = async function (query, callback) {
        var response = await fetch("http://localhost:5001/api/search/keywords/" + query, {
            method: 'GET',
            headers:headers
        });
        var data = await response.json();
        callback(data);
    }

    var searchByScore = async function (query, callback) {
        var response = await fetch("http://localhost:5001/api/search/score/" + query, {
            method: 'GET',
            headers: headers
        });
        var data = await response.json();
        callback(data);
    }
    var searchByTag = async function (query, callback) {
        var response = await fetch("http://localhost:5001/api/search/tags/" + query, {
            method: 'GET',
            headers: headers
        });
        var data = await response.json();
        callback(data);
    }

    var searchByAcceptedAnswer = async function (accepted,keywords, callback) {
        var response = await fetch("http://localhost:5001/api/search/answer/" + accepted + "/" + keywords,{
            method: 'GET',
            headers: headers
        });
        var data = await response.json();
        callback(data);
    }

    var getSearchHistory = async function (email, callback) {
        var response = await fetch("http://localhost:5001/api/search/history/user/" + email, {
            method: 'GET',
            headers: headers
        });
        var data = await response.json();
        callback(data);
    }

    var deleteSearchHistoryById = async function (historyId, callback) {
        var response = await fetch("http://localhost:5001/api/search/history/" + historyId, {
            method: 'DELETE',
            headers: headers
        });
        var data = await response.json();
        callback(data);
    }

    var deleteAllSearchHistory = async function (email, callback) {
        var response = await fetch("http://localhost:5001/api/search/history/user" + email, {
            method: 'DELETE',
            headers: headers
        });
        var data = await response.json();
        callback(data);
    }


    return {
        searchByKeyword,
        searchByScore,
        searchByTag,
        searchByAcceptedAnswer,
        getSearchHistory,
        deleteSearchHistoryById,
        deleteAllSearchHistory       
    };
});