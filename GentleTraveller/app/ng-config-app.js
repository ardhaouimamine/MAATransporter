(function () {
    'use strict';

    angular.module('app').provider('configTransporter', function () {

        this.apiRootUrl = '/api/';
        this.templateBaseUrl = 'app/';

        this.$get = function $get() {
            return this;
        };

    });

    //configTransporter.$inject = ['$routeProvider', '$locationProvider', 'RestangularProvider', '$mdThemingProvider'];
    angular
        .module('app')
        .config(function ($routeProvider, $locationProvider, RestangularProvider, $mdThemingProvider, configTransporterProvider) {

            $routeProvider.when('/', {
                templateUrl: configTransporterProvider.templateBaseUrl + 'ng_home.html',
                controller: 'homeController'
                //templateUrl: configTransporterProvider.templateBaseUrl + 'transporterlist/ng_transporterlist.html',
                //controller: 'transporterlistController',
                //module: 'app.transporterlist'
            }).
            when('/transporters', {
            templateUrl: configTransporterProvider.templateBaseUrl + 'transporterlist/ng_transporterlist.html',
            controller: 'transporterlistController',
            module: 'app.transporterlist'
            }).
            otherwise({
                redirectTo: '/'
            });
            //$locationProvider.html5Mode(true);
            RestangularProvider.setBaseUrl(configTransporterProvider.apiRootUrl);
            $mdThemingProvider.theme('default')
                              .primaryPalette('green')
                              .accentPalette('red');

            //RestangularProvider.addResponseInterceptor(function (data, operation, what, url, response, deferred) {
            //    var extractedData;
            //    // .. to look for getList operations
            //    if (operation === "getList") {
            //        // .. and handle the data and meta data
            //        extractedData = data.items;
            //        extractedData.paging =
            //        {
            //            pageCount: data.pageCount,
            //            pageNo: data.pageNo,
            //            pageSize: data.pageSize,
            //            totalRecordCount: data.totalRecordCount
            //        };
            //    } else {
            //        extractedData = data;
            //    }
            //    return extractedData;
            //});
        }).factory('TitleService', function(){
            var title = 'default';
            return {
                title: function() { return title; },
                setTitle: function(newTitle) { title = newTitle; }
            };
        });
})();