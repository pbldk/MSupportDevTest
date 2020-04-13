(function () {
 'use strict';

 angular.module('App')

  .component('orderbycustomeridcomponent', {
   restrict: "AE",
   replace: true,
   templateUrl: '/_publish/scripts/templates/orderbycustomeridcomponent.html',
   controller: ['OrderFactory', '$scope', '$location', function (OrderFactory, $scope, $location) {
    var vm = this;

    OrderFactory.OrdersByCustomerId($location.search().id).then(function (data) {
     vm.datas = data.data;
    }).catch(function (errorResponse) {
    });



   }]
  });
 //end
}());