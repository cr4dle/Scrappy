var angular = require('angular');

var model = require('../Models/EngineInput.js');

// Manual Angular Initialization
angular.element(document).ready(function () {
    angular.bootstrap(document, ['myApp']);
});

angular.module('myApp', [])
    .controller('MyController', ['$scope', function ($scope) {
    }])
    .directive('itInput', function () {
        return {
            retrict: 'E',
            scope: true,
            templateUrl: '/templates/itInputTemplate.html',
            link: function (scope, element, attrs, ctrl) {
            },
            controller: ['$scope', '$http', function MyTabsController($scope, $http) {
                $scope.userInput = model.EngineInput('c#', 'wikipedia');

                $scope.getStats = function () {
                    $http.post('http://localhost:2627/api/Scrap/Google2016', $scope.userInput)
                        .then(function successCallback(result) {
                            alert('"' + $scope.userInput.URL + '" appears in position(s): ' + result.data);
                        },
                        function errorCallback() {

                        }
                    );
                };
            }]
        };
    });