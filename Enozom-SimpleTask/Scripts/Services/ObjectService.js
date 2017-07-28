var appmodule = angular.module('objectservice', []);



app.service('JsonData', ['$http', function ($http) {
    return {
        getRespond: function () {
            return $http.get('http://localhost:61757/api/Stores/GetAllStoresData')
                .then(function (response) {
                    return response.data;
                })
        }
    }
}]); 