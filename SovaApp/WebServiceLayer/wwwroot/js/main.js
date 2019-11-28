require.config({
    baseUrl: "js",
    paths: {
        knockout: "../lib/knockout/build/output/knockout-latest.debug",
        text: "../lib/requirejs-text/text"

    }
});

require(["knockout", "app"], function (ko, app, ds) {
    //console.log(app.name);

    ko.applyBindings(app);
});