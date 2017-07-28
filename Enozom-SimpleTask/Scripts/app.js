
var appmodule = angular.module('StoresList', ['ngRoute']);


appmodule.config(function($routeProvider){
    $routeProvider
        .when('/', {
            templateUrl: 'http://localhost:61873/pages/home.html',
            controller: 'homecontroller'
        })

        .when('/List', {
            templateUrl: 'http://localhost:61873/pages/List.html',
            controller: 'listcontroller'
        })
        .when('/ControlPanel', {
            templateUrl: 'http://localhost:61873/pages/Panel.html',
            controller: 'panelcontroller'
        })
})


appmodule.service('JsonData', function ($http) {
    var factory = {};

    factory.getItems = function () {
        return $http.get('http://localhost:61757/api/Stores/GetAllStoresData');
    };

    return factory;
});

appmodule.controller('storesctrl',function($scope){
})

appmodule.controller('homecontroller',function($scope){
})







appmodule.controller('panelcontroller', function ($scope , JsonData) {
    JsonData.getItems().success(function (data) {
        $scope.items = data;
    });

    $scope.ConfirmDelete = function (id) {
        DeleteItem(id);
    }
    $scope.EditItem = function (id) {
        EditItem(id);
    }
})

function DeleteItem(Id) {
  
    $.ajax({
        type: "GET",
        url: "http://localhost:61757/api/Stores/DeleteEixtedObject/" + Id,
        contentType: false,
        processData: false,
        success: function (res) {
            location.reload();
        },
        Error: function (err) {
            console.log(Err);
        }

    })
}

function EditItem(Id) {
    $.ajax({
        type: "GET",
        url: "http://localhost:61757/api/Stores/GetStoreData/" + Id,
        contentType: false,
        processData: false,
        success: function (res) {
            console.log(res);
            $("#myModal").modal('show');
            $(".EditData").show();
            $(".SaveData").hide();
            $("#sname").val(res.StoreName);
            $("#sdes").val(res.StoreDescription);
            $("#ImageLoader").val(res.StoreLogo);
            $("#StoreId").val(res.StoreId);

            //location.reload();
        },
        Error: function (err) {
            console.log(Err);
        }

    })
}




appmodule.controller('listcontroller', function ($scope, JsonData) {

    JsonData.getItems().success(function (data) {
        $scope.items = data;
    });

    $scope.filterParam = function (value) {
        var key = "StoreName"; 
        console.log(typeof (key));
        param = {};
        param[key] = value;
        return param;
    };

});

