(function () {
    'use strict';

    angular
        .module('app')
        .factory('dataService', dataService);

    dataService.$inject = ['$location'];

    function dataService($location) {

        var photographer = {};

        var service = {
            getPhotographer: getPhotographer,
            setPhotographer: setPhotographer
        };

        return service;

        function getPhotographer() {
            return photographer;
        }

        function setPhotographer(photographer) {         
            this.photographer = photographer;

            $location.path('/Performance/Photos');
        }
    }
})();