(function () {
    'use strict';

    //Prescribe services, controllers, modules in BundleConfig.cs!
    //Remake the controllers so that they work from this service!
    angular
        .module('app')
        .factory('paginationService', paginationService);

    paginationService.$inject = [];

    function paginationService() {

        var currentPage = 0;
        var itemsPerPage = 0;

        var service = {
            range: range,
            prevPage: prevPage,
            disablePrevPage: disablePrevPage,
            nextPage: nextPage,
            disableNextPage: disableNextPage,
            getPageCount: getPageCount,
            setPage: setPage,
            setPageParam: setPageParam
        };

        return service;

        function range(data) {
            var rangeSize = 5;
            var paginationNumbers = [];
            var start;

            start = currentPage;
            if (start > getPageCount(data) - rangeSize) {
                start = getPageCount(data) - rangeSize + 1;
            }

            for (var i = start; i < start + rangeSize; i++) {
                paginationNumbers.push(i);
            }
            return paginationNumbers;
        }

        function prevPage() {
            if (currentPage > 0) {
                currentPage--;
            }
        }

        function disablePrevPage() {
            return currentPage === 0 ? "disabled" : "";
        }

        function getPageCount(data) {
            return Math.ceil(data.length / itemsPerPage) - 1;
        }

        function nextPage() {
            if (currentPage < pageCount) {
                currentPage++;
            }
        }

        function disableNextPage() {
            return currentPage === pageCount ? "disabled" : "";
        }

        function setPage(index) {
            currentPage = index;
        }

        function setPageParam(itemsCount) {
            itemsPerPage = itemsCount;
        }
    }
})();