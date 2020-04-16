(function () {
 'use strict';

 angular.module('App')

  .component('orderlistcomponent', {
   restrict: "AE",
   replace: true,
   templateUrl: '/_publish/scripts/templates/orderlist.html',
   controller: ['OrderFactory', '$scope', function (OrderFactory, $scope) {
    var vm = this;

    OrderFactory.OrdersShortList(0, 50).then(function (data) {
     vm.datas = data.data;
    }).catch(function (errorResponse) {
    });



   }]
  });
 //end
}());