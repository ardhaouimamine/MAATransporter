(function () {
    'use strict';

    angular
        .module('transporterlist')
        .controller('transporterlistController', transporterlistController);

    transporterlistController.$inject = ['Restangular','$scope'];

    function transporterlistController(Restangular, $scope) {
        /* jshint validthis:true */
        //var vm = this;
        $scope.travelers = [];

        activate();

        function activate() {
            Restangular.all('travelers').getList().then(function (travelers) {
                //vm.travelers = travelers;
                $scope.travelers = travelers;
            });
        }
    }
})();
