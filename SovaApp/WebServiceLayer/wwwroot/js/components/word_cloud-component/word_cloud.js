define(["jquery", "knockout", "jqcloud"], function ($, ko) {
    return function (params) {

        var width =  200;
        var height = 200;
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
                "text": "tortor nibh sit",
                "weight": 1.5
            },
            {
                "text": "dui nec urna suscipit nonummy. Fusce fermentum fermentum arcu. Vestibulum",
                "weight": 2.75
            },
            {
                "text": "facilisis. Suspendisse commodo tincidunt nibh. Phasellus nulla. Integer vulputate,",
                "weight": 3.25
            },
            {
                "text": "nibh. Donec est mauris, rhoncus id, mollis nec,",
                "weight": 4
            },
            {
                "text": "Donec non justo.",
                "weight": 5
            },
            {
                "text": "massa",
                "weight": 6
            },
            {
                "text": "vitae erat vel pede blandit",
                "weight": 7.75
            }
        ]


            $('#cloud').jQCloud(words,
                {
                    width: width,
                    height: height
                });
       

        return {
            word,
            weight,
            addWord
        };
    };
});