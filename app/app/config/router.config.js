(function () {
    'use strict';

    angular.module('anonymousQuestionsApp')
        .config(routerConfig);

    function routerConfig($stateProvider, $urlRouterProvider) {

        $stateProvider.state({
            name: 'home',
            component: 'home',
            url: '/home'
        });

        $urlRouterProvider.otherwise('/home');

    }

})();