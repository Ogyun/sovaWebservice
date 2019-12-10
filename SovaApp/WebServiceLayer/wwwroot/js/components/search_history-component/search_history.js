define(['knockout', 'searchService'], function (ko, ss) {


    return function () {
        var historyList = ko.observableArray([]);
        var userEmail = localStorage.getItem('email');

        var getHistoryList = function () {      
            ss.getSearchHistory(userEmail, function (response) {
                historyList(response);
                });
        }

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
            getHistoryList,
            deleteSpecificHistory,
            deleteAllHistory
        };

    }
});