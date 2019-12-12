define(['knockout', 'searchService','store'], function (ko, ss,store) {
    return function () {
    var posts = ko.observableArray([]);

    var searchClick = function () {
        var query = document.getElementById("searchInput").value;

        if (query.startsWith("tag:")) {
            var tags = query.substr(4);
            console.log(tags);
            ss.searchByTag(tags, function (response) {
                posts(response);
            });
        }

        else if (query.startsWith("score:")) {
            var score = query.substr(6);
            ss.searchByScore(score, function (response) {
                posts(response);
            });
        }

        else if (query.startsWith("accepted:")) {
            var accepted = query.substr(9, 3);
            var keywords = "";

            if (accepted.includes("yes")) {
                accepted = accepted.slice(0, 3);
                keywords = query.substr(13)
            }
            if (accepted.includes("no")) {
                accepted = accepted.slice(0, 2);
                keywords = query.substr(12)
            }
            ss.searchByAcceptedAnswer(accepted, keywords, function (response) {
                posts(response);
            });
        }

        else {
            ss.searchByKeyword(query, function (response) {
                posts(response);
                console.log(response)
            });
        }
        }

        var onPostClick = function (data) {
            store.dispatch(store.actions.selectQuestion(data));
            store.dispatch(store.actions.selectMenu("Question Overview"));
        };

    return {
        searchClick,
        posts,
        onPostClick
    };
   };
});