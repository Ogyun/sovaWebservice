define(['knockout', 'markingService', "tokenService","questionService","store"], function (ko,ms,ts,qs,store) {

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
                console.log(response.id);
                var qid = response.id;
                qs.getSpecificQuestion(qid, function (data) {
                    console.log(data);
                    store.dispatch(store.actions.selectQuestion(data));
                    store.dispatch(store.actions.selectMenu("Question Overview"));
                });
            });
            
        };

        return {
            deleteSpecificMarking,
            onMarkingClick,
            markingList
        };
    }


});