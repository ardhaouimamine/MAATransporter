(function () {
    'use strict';

    angular
    .module('app')
        .controller('layoutController', layoutController);
    layoutController.$inject = ['$mdUtil', '$mdSidenav', '$location', 'TitleService'];
    function layoutController($mdUtil, $mdSidenav, $location, TitleService) {
        var vm = this;
        vm.theTitle = TitleService;
        vm.toggleMenu = true;
        vm.selected = function (item) {
            //return $location.path().indexOf(item.url) > -1;
            return $location.path() === item.url;
        };
        vm.sideNavElements = [{ 'title': 'Home', 'url': '/' }, { 'title': 'Transporters', 'url': '/#transporters' }, { 'title': 'Trips', 'url': '/#trips' }, { 'title': 'Alerts', 'url': '/#alerts' }, { 'title': 'Favorites', 'url': '/#favorites' }];
        vm.toggleSideNav = buildToggler('left');
        //function () {
        //    //vm.toggleMenu = !vm.toggleMenu;   
        //}
        function buildToggler(navID) {
        var debounceFn = $mdUtil.debounce(function () {
            $mdSidenav(navID)
              .toggle();
        }, 100);
        return debounceFn;
    }
    };
    
})();
