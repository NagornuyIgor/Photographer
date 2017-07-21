(function () {
    'use strict';

    angular
        .module('app')
        .controller('photographerController', [photographerController]);

    photographerController.$inject = ['photographerService', '$http'];

    function photographerController(photographerService, $http) {

        var vm = this;

        vm.newPhotographer = {};

        vm.photographers = [];

        vm.getInfo = getInfo;
        vm.add = add;

        function getInfo() {
            $http.get('/api/photographers').then(function (responce) {
                vm.photographers = responce.data;
            });
        }

        function add() {
            photographerService.addPhotographer(vm.newPhotographer);/*.then(getInfo());*/
        }
    }

})();