var appNomad = angular.module('appNomad',[]);

var formCtrl = appNomad.controller('formCtrl', ['$scope', 'dataService', function ($scope, dataService) {

    $scope.message = null;
    $scope.number = null;
    $scope.runClick = function () {
        var n = $scope.number;
        if (isNaN(n))
        {
            $scope.message = "The given input is not a number.";
        }
        else if(!dataService.isInteger(n))
        {
            $scope.message = "The number must be an integer.";
        }
        else if(Number(n) <= 0)
        {
            $scope.message = "The number must be positive.";
        }
        else
        {
            $scope.message = null;

            dataService.get($scope.number)
            .then(function (response) {
                $scope.model = response.data;
            })
            .catch(function (response) { })
            .finally(function (response) { });
        }
    };
    $scope.clearClick = function () {
        $scope.number = null;
        $scope.message = null;
        $scope.model = {
            'GroupA': [],
            'GroupB': [],
            'GroupC': [],
            'GroupD': []
        };
    };
    $scope.model = {
        'GroupA' : [],
        'GroupB' : [],
        'GroupC' : [],
        'GroupD' : []
    };
}]);

var dataService = appNomad.factory('dataService', ['$http', function ($http) {
    var dataService = {
        get: function (n) {
            return $http.get('/API/PROCESS/GET/' + n);
        },
        isInteger: function(str) {
            var n = Math.floor(Number(str));
            return n !== Infinity && String(n) === str && n >= 0;
        }
    };

    return dataService;
}]);