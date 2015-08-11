'use strict';
mi9challenge.controller('inputController', ['$scope', '$http', '$rootScope', '$location', '$timeout', inputController]);

function inputController($scope, $http, $rootScope, $location, $timeout) {
    $scope.processJSON = function () {
        var outputArr  = [];
        var individualElement = '';
        try {
            
            $http.post('http://mi9challengeapp.azurewebsites.net/', this.inputText).success(function (data) {
                loadResponsePage(data);
            })
            .error(function (response) {
                individualElement = { "error": response.error };
                outputArr.push(individualElement);
                loadResponsePage(outputArr);
            });
        }
        catch (exp) {
            individualElement = { "error": "Could not decode request: JSON parsing failed" };
            outputArr.push(individualElement);
            loadResponsePage(outputArr);
        }
    };

    function loadResponsePage(outputArr)
    {
        var outputStr = JSON.stringify(outputArr);
        $location.path('/views/output');
        $timeout(function () {
            $rootScope.$broadcast('inputjsonprocessed', outputStr);
        }, 1000);
    }
}