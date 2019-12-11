define(['knockout', 'searchService','tokenService'], function (ko, ss,ts) {

    var userEmail = ts.loadToken().email;
    var historyList = ko.observableArray([]);

    //Get all history for specific user
    ss.getSearchHistory(userEmail, function (response) {
        historyList(response);
    });

    return function () {
     
        var deleteSpecificHistory = function (history) {
            ss.deleteSearchHistoryById(history.id, function (response) {
                if (response.status == 200) {
                    historyList.remove(history)
                } else {
                    alert("something went wrong");
                }
            });
        }

        var deleteAllHistory = function () {
            ss.deleteAllSearchHistory(userEmail, function (response) {
                if (response.status == 200) {
                    historyList.removeAll();
                } else {
                    alert("something went wrong");
                }
            });
        }

        return {
            historyList,
            deleteSpecificHistory,
            deleteAllHistory
        };

    }
});