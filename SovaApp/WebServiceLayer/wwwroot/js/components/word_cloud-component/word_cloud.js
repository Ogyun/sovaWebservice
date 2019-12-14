define(["jquery", "knockout", "jqcloud"], function ($, ko) {
    return function (params) {

        var width =  450;
        var height = 250;
       // var words = [];

        var word = ko.observable();
        var weight = ko.observable();
        var addWord = function () {
            words.push({ text: word(), weight: weight() });
            word("");
            weight("");
            $('#cloud').jQCloud('update', words);
        };


        var words = [
            {
                text: "tortor",
                weight: 1.5
            },
            {
                text: "dui",
                weight: 2.75
            },
            {
                text: "facilisis",
                weight: 3.25
            },
            {
                text: "nibh",
                weight: 4
            },
            {
                text: "Donec",
                weight: 5
            },
            {
                text: "massa",
                weight: 6
            },
            {
                text: "vitae",
                weight: 7.75
            }
        ]


            $('#cloud').jQCloud(words,
                {
                    width: width,
                    autoResize: true,
                    height: height
                });
       

        return {
            word,
            weight,
            addWord
        };
    };
});