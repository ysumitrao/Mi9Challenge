'use strict';
var mi9challenge = angular.module('mi9challenge', ['ngRoute']);

mi9challenge.config(function ($routeProvider) {
    $routeProvider
    .when('/',
    {
        controller: 'inputController',
        templateUrl: 'Views/Input.html'
    })
    .when('/views/output',
    {
        controller: 'outputController',
        templateUrl: 'Views/Output.html'
    })
    .otherwise({ redirectTo: '/' });
});