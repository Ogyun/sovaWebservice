define(['knockout', 'searchService'], function (ko, ss) {
    return function () {
    var posts = ko.observableArray([]);

    var searchClick = function () {
        var query = document.getElementById("searchInput").value;
        ss.searchByKeyword(query, function (response) {
            posts(response);
            console.log(response[0])
        });
    }

    return {
        searchClick,
        posts
    };
   };
});