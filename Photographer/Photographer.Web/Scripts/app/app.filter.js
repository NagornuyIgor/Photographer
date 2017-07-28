(function () {
    'use strict';

    angular.
        module('app')
        .filter('appFilter', appFilter);

    function appFilter() {
        return function (input, start) {
            start = parseInt(start, 10);
            return input.slice(start);
			};
        }
})();