﻿define(['knockout', 'searchService','store'], function (ko, ss,store) {
    return function () {
        var posts = ko.observableArray([]);



        var searchClick = function () {
            //posts(
            //    { "questionId": "1789945", "title": "title1", "body": "<p>How can I check if one string contains another …ethod, but there doesn't seem to be one.</p>&#xA;" },
            //    { "questionId": 9329446, "title": "title2", "body": "<h2>For Actual Arrays</h2>&#xA;&#xA;<p><em>(See s important to test.</p>&#xA" },
            //    { "questionId": 359494, "title": "title3", "body": "<p>The identity (<code>===</code>) operator behave…ational.org/ecma-262/5.1/#sec-11.9.3</a></p>&#xA;" },
            //    { "questionId": 1995113, "title": "title4", "body": "<p>I'm using <a href=http://en.wikipedia.org/wiki…a performance gain over <code>==</code>?</p>&#xA, creationDate" }
            //);
        var query = document.getElementById("searchInput").value;

        if (query.startsWith("tag:")) {
            var tags = query.substr(4);
            
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