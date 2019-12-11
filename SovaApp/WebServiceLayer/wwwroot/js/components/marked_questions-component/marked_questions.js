define(['knockout', 'markingService', "tokenService"], function (ko, ms,ts) {

    var userEmail = ts.loadToken().email;
    var markingList = ko.observableArray([]);

    //Get all Markings for specific user
    ms.getMarkings(userEmail, function (response) {
        markingList(response.items);
    });

    return function () {

        var deleteSpecificMarking = function (marking) {
            ms.deleteSpecificMarking(marking.link, function (response) {
                if (response.status == 200) {
                    markingList.remove(marking)
                } else {
                    alert("something went wrong");
                }
            });
        }

        var onMarkingClick = function (marking) {
            ms.getSpecificMarking(marking.link, function (response) {
                console.log(response)
            });
        };

        return {
            deleteSpecificMarking,
            onMarkingClick,
            markingList
        };
    }


});