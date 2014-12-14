app.controller("MainController", ['$scope', '$http', '$window', 'mainService', '$rootScope', function ($scope, $http, $window, mainService, $rootScope) {
    
    $scope = mainService.initForm($scope, $http);

}]).service('mainService',['$rootScope',  function ($rootScope) {
    var service = this;

    service.initForm = function (scope, http) {
        scope.dataEnum = this.initializeData();
        scope.offerTypeGroup = scope.dataEnum.OfferTypeGroup;
        return scope;
    };

    service.initializeData = function () {
        var dataEnum = model;
        console.log(dataEnum);

        return dataEnum;
    };
}]).directive('offerCategoryBroadcast', ['$rootScope', function ($rootScope) {
    return {
        restrict: 'A',
        link: function (scope, elem, attrs) {
            elem.bind('change', function () {
                console.log('offerCategoryChanged');
                console.log('elemVal: ' + elem.val());
                $rootScope.$broadcast('offerCategoryChanged', { params: { val: elem.val() } });
            });
        }
    };
}]).directive('offerTypeRadioButtons', ['$http', '$rootScope', function ($http, $rootScope) {
    return {
        replace: true,
        restrict: 'E',
        require: 'ngModel',
        scope: true,
        link: function (scope, elem, attrs, ctrl) {
            scope.$on('offerCategoryChanged', function (evt, args) {
                var offerTypeUrl = "/home/offertypes/" + args.params.val;
                $http({
                    method: 'GET',
                    url: offerTypeUrl,
                    }).success(function (data) {
                        console.log("Success");
                        scope.offerTypeGroup = data;
                        scope.offerTypeGroup.forEach(function (entry) {
                            console.log(entry);
                        });
                    }).error(function (err) {
                        console.log("Fail");
                    });
            });
        },
        template: function (ele, attrs) {
            var template = '<div class="pure-u-1-1">' +
                                '<div id="offerTypeRadio" ng-repeat="offerTypeEntry in offerTypeGroup" class="pure-u-1-3">' +
                                      '<input id="{{offerTypeEntry.name}}" name="{{offerTypeEntry.name}}" type="radio" value="{{offerTypeEntry.val}}" data-ng-model="' + attrs.ngModel + '">' +
                                      '<label for="{{offerTypeEntry.name}}">{{offerTypeEntry.name}}</label>'
                                '</div>' +
                           '</div>';
            return template;
        }
    }
}]);