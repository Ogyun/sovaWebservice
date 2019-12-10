define([], function () {

    var token = localStorage.getItem('token');
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
        });//.then(function (response) {
        //    if (response.status == 200) {
        //        console.log("status 200");
        //    }
        //    else {
        //        console.log("something went wrong");
        //    }
        //    return response;
        //});
        var data = await response;
        callback(data);
    }

    var deleteAllSearchHistory = async function (email, callback) {
        var response = await fetch("http://localhost:5001/api/search/history/user/" + email, {
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