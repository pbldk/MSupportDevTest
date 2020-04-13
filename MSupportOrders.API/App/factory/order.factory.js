
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