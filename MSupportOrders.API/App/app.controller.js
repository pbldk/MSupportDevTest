(function () {
	'use strict';

	/* initialize angular */
	angular.module('App')
		.controller('BaseCtrl', ['$window', '$rootScope', '$location', 'OrderFactory', '$timeout', function ($window, $rootScope, $location, OrderFactory, $timeout) {

			var vm = this;
			$rootScope.userFunc = {}


			//init application

			$rootScope.userFunc.showappstarting = true;
			$rootScope.userFunc.applicationinit = false;
			$timeout(function () {
				OrderFactory.OrdersShortList(0, 50).then(function (response) {
					$rootScope.userFunc.applicationinit = true;			
					$rootScope.userFunc.showappstarting = false;
				});
			}, 2000);

			
			$rootScope.userFunc.goBack = function () {
				$window.history.back();
			}
			$rootScope.userFunc.showhistory = false;

			// close application
			$rootScope.userFunc.CloseApplication = function () {
				console.log("click");
				$rootScope.userFunc.applicationinit = false;
				$rootScope.userFunc.showappstarting = false;
				$rootScope.userFunc.showloggedout = true;
			}


	
	

			// navigation
			vm.oneAtATime = true;


			vm.status = {
				isCustomHeaderOpen: false,
				isFirstOpen: true,
				isFirstDisabled: false
			};
		}]);
	//end
}());