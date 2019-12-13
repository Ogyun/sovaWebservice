define(["tokenService"], function (ts) {
  
    var headers = ts.loadToken().headers;

    var getMarkings = async function (email, callback) {
        var response = await fetch("http://localhost:5001/api/markings/" + email, {
            method: 'GET',
            headers: headers
        });
        var data = await response.json();
        callback(data);
    }

    //This should be replaced with getQuestion
    var getSpecificMarking = async function (markingLink, callback) {
        var response = await fetch(markingLink, {
            method: 'GET',
            headers: headers
        });
        var data = await response.json();
        callback(data);
    }

    var deleteSpecificMarking = async function (markingLink, callback) {
        var response = await fetch(markingLink, {
            method: 'DELETE',
            headers: headers
        });
        var data = await response;
        callback(data);
    }

    var createMarking = async function (email, questionId, callback) {
        var response = await fetch("http://localhost:5001/api/markings/", {
            method: 'POST',
            headers: headers,
            body: JSON.stringify({ "UserEmail": email, "QuestionId": questionId })
        }).then(function (response) {
            if (response.status == 400) {
                alert("This question is already marked");
            }
            return response;
        });
        var data = await response.json();
        callback(data);
    }

    return {
        getMarkings,
        getSpecificMarking,
        deleteSpecificMarking,
        createMarking


    };
});