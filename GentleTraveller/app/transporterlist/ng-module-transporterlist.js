(function () {
    'use strict';

    angular.module('transporterlist', [
        // Angular modules 
        'ngRoute',
        'restangular',
        'ngMaterial',
        'ngMdIcons',
        // Custom modules 

        // 3rd Party Modules
        
    ]);
    angular.module('transporterlist').controller('layoutController', layoutController);
    layoutController.$inject = ['$mdSidenav'];
    function layoutController($mdSidenav) {
        var vm = this;
        vm.toggleMenu = true;
        vm.selected = null;
        vm.sideNavElements = ['Home', 'Trips', 'Alerts', 'Favorites'];
        vm.toggleSideNav = function () {
            //$mdSidenav('left').toggle();
            vm.toggleMenu = !vm.toggleMenu;
        }
    };
})();