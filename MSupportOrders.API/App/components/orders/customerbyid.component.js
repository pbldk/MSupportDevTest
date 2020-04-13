(function () {
 'use strict';

 angular.module('App')

  .component('customerbyidcomponent', {
   restrict: "AE",
   replace: true,
   templateUrl: '/_publish/scripts/templates/customerbyidcomponent.html',
   controller: ['CustomerFactory', '$scope', '$location','$rootScope', function (CustomerFactory, $scope, $location,$rootScope) {
    var vm = this;
    //initialize history
    $rootScope.userFunc.showhistory= true;
    CustomerFactory.CustomersById($location.search().id).then(function (data) {
     vm.datas = data.data;
    }).catch(function (errorResponse) {
    });



   }]
  });
 //end
}());