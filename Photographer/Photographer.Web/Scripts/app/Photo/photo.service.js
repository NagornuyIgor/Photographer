(function () {
    'use strict';

    angular
        .module('app')
        .factory('photoService', photoService);

    photoService.$inject = ['$http', 'Upload'];

    function photoService($http, Upload) {

        var service = {
            getPhotos: getPhotos,
            upload: upload,
            deletePhoto: deletePhoto
        };

        return service;

        function getPhotos(PhotographerId) {
            return $http.get('/api/Photos/' + PhotographerId);   
        }

        function upload(Content) {
            return Upload.upload({
                url: '/api/Photos/Add',
                data: { Content: Content }
            });
        }

        function deletePhoto(id) {
            return $http.delete('/api/Photos/', { params: { id: id }});
        }
    }

})();