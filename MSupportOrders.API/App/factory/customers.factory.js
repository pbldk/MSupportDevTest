
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