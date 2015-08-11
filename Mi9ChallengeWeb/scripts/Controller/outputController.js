'use strict';
mi9challenge.controller('outputController', ['$scope', '$rootScope', outputController]);

function outputController($scope, $rootScope) {
    $scope.outputString = 'Loading...';
    $rootScope.$on('inputjsonprocessed', function (event, data) {
        $scope.outputString = data;
    });
}