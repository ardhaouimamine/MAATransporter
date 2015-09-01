(function () {
    'use strict';

    angular.module('transporterlist').provider('configTransporter', function () {

        this.apiRootUrl = '/api/';
        this.templateBaseUrl = 'app/transporterlist/';

        //this.assetsUrl = '/assets/';
        //this.assetsAngularUrl = this.assetsUrl + 'angular/';

        this.$get = function $get() {
            return this;
        };

    });

    //configTransporter.$inject = ['$routeProvider', '$locationProvider', 'RestangularProvider', '$mdThemingProvider'];
    angular
        .module('transporterlist')
        .config(function ($routeProvider, $locationProvider, RestangularProvider, $mdThemingProvider, configTransporterProvider) {

            $routeProvider.when('/', {
                templateUrl: configTransporterProvider.templateBaseUrl + 'ng_transporterlist.html',
                controller: 'transporterlistController'
            }).
            otherwise({
                redirectTo: '/'
            });
            $locationProvider.html5Mode(true);
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
        });
})();