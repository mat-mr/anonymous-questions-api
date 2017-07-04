(function () {
    'use strict';

    angular.module('anonymousQuestionsApp')
        .component('home', {
            templateUrl: './app/modules/home/home.html',
            controller: homeController,
            controllerAs: 'vm',
            bindings: {
            }
        });

    class homeController {

    }

})();