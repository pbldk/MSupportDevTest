(function () {
 'use strict';
 angular.module("App")
  .config(['$routeProvider', '$locationProvider', function ($routeProvider) {
   $routeProvider.when("/orderbyid", {
    templateUrl: "/_publish/scripts/views/orderbyid.html"
   });
   $routeProvider.when("/customers", {
    templateUrl: "/_publish/scripts/views/customerslist.html"
   });
   $routeProvider.when("/customerbyid", {
    templateUrl: "/_publish/scripts/views/customerbyid.html"
   });
   $routeProvider.otherwise({
    redirectTo: "/",
    templateUrl: "/_publish/scripts/views/start.html"
   });
  }]);
 //end
}());