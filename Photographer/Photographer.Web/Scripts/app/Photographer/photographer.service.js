(function () {
    'use strict';

    angular
        .module('app')
        .factory('photographerService', photographerService);

    photographerService.$inject = ['$http'];

    function photographerService($http)
    {
        var service = {
            getPhotographers: getPhotographers,
            addPhotographer: addPhotographer
        };

        return service;

        function getPhotographers() {
            return $http.get('/api/Photographers');
        }

        function addPhotographer(photographer) {
            return $http.post('/api/photographers/Add', photographer).then(function (status) {
                    console.log(status);
            });
        }
    }

})();