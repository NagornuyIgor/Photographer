(function () {
    'use strict';

    angular
        .module('app')
        .controller('photoController', photoController);

    photoController.$inject = ['photoService', 'dataService', '$http', '$routeParams'];

    function photoController(photoService, dataService, $http, $routeParams) {
        var vm = this;

        vm.photos = [];

        //vm.uploadedPhoto = {};

        vm.params = {
            photographerId: $routeParams.id,
            photographerName: $routeParams.name
        };

        vm.content = { };

        vm.uploadPhoto = uploadPhoto;
        vm.getPhotos = getPhotos;
        vm.deletePhoto = deletePhoto;
        vm.download = download;

        function getPhotos() {
            photoService.getPhotos(vm.params.photographerId).then(function (response) {
                vm.photos = response.data;
            });  
        }

        function uploadPhoto(Content) {
            if (Content) {
                vm.content = {
                    PhotographerId: vm.params.photographerId,
                    Content: Content
                };
                photoService.upload(vm.content).then(function (status) {
                    console.log(status);
                    getPhotos();
                });
            }
        }

        function deletePhoto(id) {
            photoService.deletePhoto(id).then(function (status) {
                console.log(status);
                getPhotos();
            });
        }

        function download(Name) {
            $http.get('/Uploads/' + Name, { responseType: "arraybuffer" }).success(function (data) {

                var arrayBufferView = new Uint8Array(data);
                var blob = new Blob([arrayBufferView], { type: "image/*" });
                //var urlCreator = window.URL || window.webkitURL;
                //var imageUrl = urlCreator.createObjectURL(blob);
                //var img = document.querySelector("#photo");
                //img.src = imageUrl;
                // code to download image here


            }).error(function (err, status) { });
        }
    }

    //qhttp://localhost:50027/Uploads/3417005c-ac7d-4c62-a273-d700583e0ae8.jpg

})();