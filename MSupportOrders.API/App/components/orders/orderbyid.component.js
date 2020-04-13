(function () {
 'use strict';

 angular.module('App')

  .component('orderbyidcomponent', {
   restrict: "AE",
   replace: true,
   templateUrl: '/_publish/scripts/templates/orderbyidcomponent.html',
   controller: ['OrderFactory', '$scope', '$location', '$rootScope', function (OrderFactory, $scope, $location, $rootScope) {
    var vm = this;
    //initialize history
    $rootScope.userFunc.showhistory = true;
    OrderFactory.OrderCompleteWithOrderlines($location.search().id).then(function (data) {
     vm.datas = data.data;
    }).catch(function (errorResponse) {
    });



   }]
  });
 //end
}());