(function () {
 'use strict';

 angular.module('App')
 
  .component('orderstatisticscomponent', {
   restrict: "AE",
   replace: true,
   templateUrl: '/_publish/scripts/templates/orderstatistics.html',
   controller: ['StatisticsFactory', '$scope', function (StatisticsFactory, $scope) {
    var vm = this;

    StatisticsFactory.OrdersShortList(0, 10).then(function (data) {   
     vm.datas = data.data;
    }).catch(function (errorResponse) {
    });



   }]
  });
 //end
}());