define(["knockout", "store", "tokenService"], function (ko, store, ts) {
    var currentComponent = ko.observable("login-component");
    var navbarVisible = ko.observable(false);

    var changeComponent = () => {
        if (currentComponent() === "login-component") {
            currentComponent("signup-component");
        } else {
            currentComponent("login-component");
        }
    };

    var menuElements = [
        {
            name: "Home",
            component: "search-component"
        },
        {
            name: "Notes",
            component: "note-component"
        },
        {
            name: "History",
            component: "search_history-component"
        },
        {
            name: "Markings",
            component: "marked_questions-component"
        },
        {
            name: "Profile",
            component: "userinfo-component"
        },
        {
            name: "Question Overview",
            component: "question-component"
        },
        {
            name: "Word Cloud",
            component: "word_cloud-component"
        }
    
    ];

    var currentMenu = ko.observable(menuElements[0]);
    var currentComp = ko.observable(currentMenu().component);

    var changeContent = function (menu) {
        store.dispatch(store.actions.selectMenu(menu.name));
    };

    store.subscribe(() => {
        var menuName = store.getState().selectedMenu;
        var menu = menuElements.find(x => x.name === menuName);
        if (menu) {
            currentMenu(menu);
            currentComp(menu.component);
        }
    });

    var isSelected = function (menu) {
        return menu === currentMenu() ? "active" : "";
    };

    var showLogin = ko.observable(true);
    if (ts.checkToken() == false) {
        showLogin = true;
    }
    else { showLogin = false; }

    return {
        currentComponent,
        changeComponent,
        currentComp,
        menuElements,
        changeContent,
        isSelected,
        navbarVisible,
        showLogin
    };
});