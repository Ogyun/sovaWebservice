define(['knockout', 'searchService'], function (ko, ss) {

    var userEmail = localStorage.getItem('email');
    var historyList = ko.observableArray([]);

    //Get all history for specific user
    ss.getSearchHistory(userEmail, function (response) {
        historyList(response);
    });

    return function () {
     
        var deleteSpecificHistory = function (historyId) {
            ss.deleteSearchHistoryById(historyId, function (response) {
                console.log(response);
            });
        }

        var deleteAllHistory = function () {
            ss.deleteAllSearchHistory(userEmail, function (response) {
                console.log(response);
            });
        }

        return {
            historyList,
            deleteSpecificHistory,
            deleteAllHistory
        };

    }
});