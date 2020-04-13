(function () {
 'use strict';

 angular.module('App')

  .component('customerlistcomponent', {
   restrict: "AE",
   replace: true,
   templateUrl: '/_publish/scripts/templates/customerslistcomponent.html',
   controller: ['CustomerFactory', '$scope', function (CustomerFactory, $scope) {
    var vm = this;

    CustomerFactory.CustomersAll().then(function (data) {
     vm.datas = data.data;
   
    }).catch(function (errorResponse) {
    });



   }]
  });
 //end
}());