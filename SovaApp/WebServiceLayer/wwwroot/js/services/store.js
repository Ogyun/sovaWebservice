﻿define([], function () {

    const selectMenu = "SELECT_MENU";
    const selectQuestion = "SELECT_QUESTION";

    var subscribers = [];

    var currentState = {};

    var getState = () => currentState;

    var subscribe = function (callback) {
        subscribers.push(callback);

        return function () {
            subscribers = subscribers.filter(x => x !== callback);
        };
    };

    var reducer = function (state, action) {
        switch (action.type) {
            case selectMenu:
                return Object.assign({}, state, { selectedMenu: action.selectedMenu });
            case selectQuestion:
                return Object.assign({}, state, { selectedQuestion: action.selectedQuestion });
            default:
                return state;
        }
    };

    var dispatch = function (action) {
        currentState = reducer(currentState, action);

        subscribers.forEach(callback => callback());
    };

    var actions = {
        selectMenu: function (menu) {
            return {
                type: selectMenu,
                selectedMenu: menu
            };
        },
        selectQuestion: function (question) {
            return {
                type: selectQuestion,
                selectedQuestion: question
            };
        }
    };

    return {
        getState,
        subscribe,
        dispatch,
        actions
    };


});