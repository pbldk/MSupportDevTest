(function () {
  'use strict';

  /* initialize angular */
 angular.module('App', ['ngAnimate', 'ngSanitize', 'ngAria', 'ngResource', 'ngRoute', 'ui.bootstrap'])
    .config(['$compileProvider', function ($compileProvider) {
      $compileProvider.debugInfoEnabled(false);
    }])
    .run(['$rootScope', function ($rootScope) {


    }]);

}());
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

(function () {
	'use strict';

	/* initialize angular */
	angular.module('App')
		.factory('CustomerFactory', ['$http', function ($http) {
			return {
				CustomersAll: function () {
					return $http({
						method: 'GET',
						cache: false,
						url: '/api/Customers/CustomersAll'

					}).then(function (response) {
						return response;
					}, function (response) {
					});
				},
				CustomersById: function (_paramID) {
					return $http({
						method: 'GET',
						cache: false,
						url: '/api/Customers/CustomerByID',
						params:
						{
							_paramID: _paramID				
						}
					}).then(function (response) {
						return response;
					}, function (response) {
					});
				}
			}
		}])
	//end
}());

(function () {
	'use strict';

	/* initialize angular */
	angular.module('App')
		.factory('OrderFactory', ['$http', function ($http) {
			return {
				OrdersShortList: function (_paramFrom, _paramTo) {
					return $http({
						method: 'GET',
						cache: false,
						url: '/api/Order/OrderWithTotalsList',
						params:
						{
							_paramFrom: _paramFrom,
							_paramTo: _paramTo
						}
					}).then(function (response) {
						return response;
					}, function (response) {
					});
				},		
				OrderCompleteWithOrderlines: function (_paramOrderID) {
					return $http({
						method: 'GET',
						cache: false,
						url: '/api/Order/OrderCompleteWithOrderlines',
						params:
						{
							_paramOrderID: _paramOrderID						
						}
					}).then(function (response) {
						return response;
					}, function (response) {
					});
				}
				,
				OrdersByCustomerId: function (_paramID) {
					return $http({
						method: 'GET',
						cache: false,
						url: '/api/Order/OrdersByCustomerID',
						params:
						{
							_paramID: _paramID
						}
					}).then(function (response) {
						return response;
					}, function (response) {
					});
				}
			}
		}])
	//end
}());