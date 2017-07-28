(function () {
    'use strict';

    angular
        .module('app')
        .controller('photographerController', photographerController);

    photographerController.$inject = ['photographerService', '$http'];

    function photographerController(photographerService, $http) {

        var vm = this;

        vm.itemsPerPage = 3;
        vm.currentPage = 0;
        vm.pageCount = 0;

        vm.newPhotographer = {
            Name: '',
            BirthDate: null
        };

        vm.photographers = [];

        vm.pageLoad = pageLoad;
        vm.getInfo = getInfo;
        vm.add = add;

        vm.range = range;
        vm.prevPage = prevPage;
        vm.disablePrevPage = disablePrevPage;
        vm.nextPage = nextPage;
        vm.disableNextPage = disableNextPage;
        vm.setPage = setPage;

        function pageLoad() {
            getInfo().then(function (result) {
                vm.photographers = result;

                vm.pageCount = getPageCount();
            });

        }

        function getInfo() {
            return photographerService.getPhotographers();
        }

        function add() {
            if (vm.newPhotographer.Name !== '' && vm.newPhotographer.Name !== null) {
                photographerService.addPhotographer(vm.newPhotographer).then(function () {
                    pageLoad();
                });

                vm.newPhotographer = {
                    Name: '',
                    BirthDate: null
                };
            }
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
               return vm.currentPage--;
            }
        }

        function disablePrevPage() {
            return vm.currentPage === 0 ? "disabled" : "";
        }

        function getPageCount() {
            return Math.ceil(vm.photographers.Photographers.length / vm.itemsPerPage) - 1;
        }

        function nextPage() {
            if (vm.currentPage < vm.pageCount) {
               return vm.currentPage++;
            }
        }

        function disableNextPage() {
            return vm.currentPage === vm.pageCount ? "disabled" : "";
        }

        function setPage(index) {
            vm.currentPage = index;
        }

        //vm.range = range;
        //vm.prevPage = prevPage;
        //vm.disablePrevPage = disablePrevPage;
        //vm.nextPage = nextPage;
        //vm.disableNextPage = disableNextPage;
        //vm.setPage = setPage;

        //function range(data) {
        //    photographerService.range(data);
        //}

        //function prevPage() {
        //    photographerService.prevPage();
        //}

        //function disablePrevPage() {
        //    photographerService.disablePrevPage();
        //}

        //function nextPage() {
        //    photographerService.nextPage();
        //}

        //function disableNextPage() {
        //    photographerService.disableNextPage();
        //}

        //function setPage(index) {
        //    photographerService.setPage(index);
        //}

    }

})();