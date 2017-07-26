(function () {
    'use strict';

    angular
        .module('app')
        .controller('photoController', photoController);

    photoController.$inject = ['photoService', 'dataService', '$http'];

    function photoController(photoService, dataService, $http) {
        var vm = this;

        vm.photos = [];

        //vm.photographer = {};
        vm.content = {};

        vm.uploadPhoto = uploadPhoto;
        vm.getPhotos = getPhotos;
        vm.deletePhoto = deletePhoto;


        function getPhotos() {

            photoService.getPhotos().then(function (response) {
               vm.photos = response.data;
            });  

            //vm.photographer = dataService.getPhotographer();

            //photoService.getPhotos(vm.photographer.Id).then(function (response) {
            //   vm.photos = response.data;
            //});  
        }

        function uploadPhoto(Content, Id) {

            vm.content = {
                PhotographerId: Id,
                Content: Content
            };

            if (vm.content.Content) {
                photoService.upload(vm.content);
            }
        }

        function deletePhoto(id) {
            photoService.deletePhoto(id).then(function (status) {
                console.log(status);
                getPhotos();
            });
        }

        //function getPhotographer() {
        //    vm.photographer = dataService.getPhotographer();
        //}

        //function uploadPhoto() {        
        //    var reader = new FileReader();

        //    reader.onloadend = function (event) {
        //        vm.photo = event.target.result;
        //        //send your binary data via $http or $resource or do anything else with it
        //        photoService.upload(vm.photo);
        //    };
        //}

    }

})();