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