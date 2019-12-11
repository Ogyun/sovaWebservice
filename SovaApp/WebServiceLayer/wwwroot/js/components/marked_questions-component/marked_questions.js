define(['knockout', 'markingService'], function (ko, ms) {

    var userEmail = localStorage.getItem('email');
    var markingList = ko.observableArray([]);

    //Get all Markings for specific user
    ms.getMarkings(userEmail, function (response) {
        markingList(response.items);
        console.log(response.items[0])
    });

    return function () {

        var deleteSpecificMarking = function (marking) {
            ms.deleteSpecificMarking(marking.email,marking.questionId, function (response) {
                if (response.status == 200) {
                    historyList.remove(history)
                } else {
                    alert("something went wrong");
                }
            });
        }

        var onMarkingClick = function () {
            console.log("onMarkinClicked");
        }

        return {
            deleteSpecificMarking,
            onMarkingClick,
            markingList
        };
    }


});