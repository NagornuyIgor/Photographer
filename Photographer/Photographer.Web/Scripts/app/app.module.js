(function () {
    'use strict';
    
    angular.module('app', [

        // Angular modules
        'ngRoute',

        // 3rd Party Modules
        'ngFileUpload'
    ])
        .config(config);

    function config($routeProvider, $locationProvider) {
        $routeProvider
            .when('/:name/:id', {
                templateUrl: 'Scripts/app/Photo/Photos.html',
                controller: 'photoController',
                controllerAs: 'vm'
            })
            .otherwise({
                templateUrl: 'Scripts/app/Photographer/Photographers.html',
                controller: 'photographerController',
                controllerAs: 'vm'
            });
            //.when('/Photographers', {
            //    templateUrl: 'Scripts/app/Photographer/Photographers.html',
            //    controller: 'photographerController',
            //    controllerAs: 'vm'
            //})

        //*Host/#!/Controller
    }
})();