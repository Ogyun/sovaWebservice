define(["knockout", "store"], function (ko, store) {
    var currentComponent = ko.observable("login-component");
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

    return {
        currentComponent,
        changeComponent,
        currentComp,
        menuElements,
        changeContent,
        isSelected
    };
});