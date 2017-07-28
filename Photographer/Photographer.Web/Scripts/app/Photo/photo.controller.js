(function () {
    'use strict';

    angular
        .module('app')
        .controller('photoController', photoController);

    photoController.$inject = ['photoService', '$http', '$routeParams'];

    function photoController(photoService, $http, $routeParams) {
        var vm = this;

        vm.photos = [];

        vm.itemsPerPage = 11;
        vm.currentPage = 0;
        vm.pageCount = 0;

        vm.params = {
            photographerId: $routeParams.id,
            photographerName: $routeParams.name
        };

        vm.content = { };

        vm.uploadPhoto = uploadPhoto;
        vm.getPhotos = getPhotos;
        vm.deletePhoto = deletePhoto;

        vm.range = range;
        vm.prevPage = prevPage;
        vm.disablePrevPage = disablePrevPage;
        vm.nextPage = nextPage;
        vm.disableNextPage = disableNextPage;
        vm.setPage = setPage;

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

        function range() {
            var rangeSize = 3;
            var paginationNumbers = [];
            var start;

            start = vm.currentPage;
            if (start > getPageCount() - rangeSize) {
                start = getPageCount() - rangeSize + 1;
            }

            for (var i = start; i < start + rangeSize; i++) {
                paginationNumbers.push(i);
            }
            return paginationNumbers;
        }

        function prevPage() {
            if (vm.currentPage > 0) {
                vm.currentPage--;
            }
        }

        function disablePrevPage() {
            return vm.currentPage === 0 ? "disabled" : "";
        }

        function getPageCount() {
            return Math.ceil(vm.photos.Photos.length / vm.itemsPerPage) - 1;
        }

        function nextPage() {
            if (vm.currentPage < vm.pageCount) {
                vm.currentPage++;
            }
        }

        function disableNextPage() {
            return vm.currentPage === vm.pageCount ? "disabled" : "";
        }

        function setPage(index) {
            vm.currentPage = index;
        }
    }
})();