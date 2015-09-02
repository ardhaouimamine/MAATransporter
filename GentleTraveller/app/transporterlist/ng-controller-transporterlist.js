(function () {
    'use strict';

    angular
        .module('app.transporterlist')
        .controller('transporterlistController', transporterlistController);

    transporterlistController.$inject = ['Restangular', '$scope', 'TitleService'];

    function transporterlistController(Restangular, $scope, TitleService) {
        /* jshint validthis:true */
        //var vm = this;
        TitleService.setTitle('Transporters');
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
