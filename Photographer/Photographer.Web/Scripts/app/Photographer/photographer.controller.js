(function () {
    'use strict';

    angular
        .module('app')
        .controller('photographerController', photographerController);

    photographerController.$inject = ['photographerService', 'dataService', '$http'];

    function photographerController(photographerService, dataService, $http) {

        var vm = this;

        vm.newPhotographer = {
            Name: '',
            BirthDate: null
        };

        vm.photographers = [];

        vm.getInfo = getInfo;
        vm.add = add;
        //vm.set = set;

        function getInfo() {
            $http.get('/api/Photographers').then(function (response) {
                vm.photographers = response.data;

                vm.newPhotographer = {
                    Name: '',
                    BirthDate: null
                };
            });
        }

        function add() {
            photographerService.addPhotographer(vm.newPhotographer).then(function () {
                getInfo();
            });
        }

        //function set(photographer) {
        //    dataService.setPhotographer(photographer);
        //}
    }

})();