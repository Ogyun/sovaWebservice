define(["jquery", "knockout", "searchService", "tokenService", "jqcloud"], function ($, ko,ss,ts) {

    return function (params) {

        var width =  450;
        var height = 250;

        var userEmail = ts.loadToken().email;
        var words = [];
        ss.getSearchHistoryWordCloud(userEmail, function (response,status) {
            if (status==200) {
                words = response;
                console.log(status)
            } else {
                alert("Something went wrong"+status)
            }

            $('#cloud').jQCloud(words,
                {
                    width: width,
                    autoResize: true,
                    height: height
                });
        });

    };
});