define(['knockout', 'searchService'], function (ko, ss) {


    return function () {
        var historyList = ko.observableArray([]);
        //get email from token
       

        var getHistoryList = function () {
            var userEmail = localStorage.getItem('email');

            ss.getSearchHistory(userEmail, function (response) {
                historyList(response);
                    console.log(response);
                });
        }

        var deleteSpecificHistory = function (historyId) {
            ss.deleteSearchHistoryById(historyId, function (response) {
                console.log(response);
            });
        }

        var deleteAllHistory = function () {
            ss.deleteAllSearchHistory(email, function (response) {
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