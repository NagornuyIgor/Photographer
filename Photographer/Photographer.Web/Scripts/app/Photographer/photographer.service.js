(function () {
    'use strict';

    angular
        .module('app')
        .factory('photographerService', [photographerService]);

    photographerService.$inject = ['$http'];

    function photographerService($http)
    {
        var service = {
            addPhotographer: addPhotographer
        };

        return service;

        function addPhotographer(photographer) {
            return $http.post('Add', photographer);
        }
    }

})();