define([], function () {

    var token = localStorage.getItem('token');
    var headers = new Headers();
    headers.append('Authorization', 'Bearer ' + token);


    var getSpecificQuestion = async function (questionId, callback) {
        var response = await fetch("http://localhost:5001/api/questions/" + questionId, {
            method: 'GET',
            headers: headers
        });
        var data = await response.json();
        callback(data);
    }

    var getQuestionAnswers =  = async function (questionId, callback) {
        var response = await fetch("http://localhost:5001/api/" + questionId +"/answers", {
            method: 'GET',
            headers: headers
        });
        var data = await response.json();
        callback(data);
    }

    return {
        getSpecificQuestion,
        getQuestionAnswers



    };
});