var app = angular.module("Myapp", []);

app.controller("DashboardController", function ($scope, $http) {


    $scope.savedata= function () {

        $scope.btntext = "Please Wait..";

        $http({

            method: 'POST',

            url: '/Dashboard/Add_record',

            data: $scope.register

        }).success(function (d) {

            $scope.btntext = "Save";

            $scope.register = null;

            alert(d);

        }).error(function () {

            alert('Failed');

        });

    };

    $scope.btntext = "Save";
    // Display all records

        $http.get("/Dashboard/GetData").then(function (d) {

            $scope.record = d.data;


        }, function (error) {
            console.log(error)
        });


    // Display record by id
    $scope.loadrecord = function (id) {

        $http.get("/Dashboard/Get_databyid?id=" + id).then(function (d) {

            $scope.myregister = d.data;

        }, function (error) {

                alert('Type a valid ID to search!', error);

        });

    };
   
    // Delete record

    $scope.deleterecord = function (id) {

        $http.get("/Dashboard/delete_record?id=" + id).then(function (d) {

            $http.get("/Dashboard/GetData").then(function (d) {

                $scope.record = d.data;

            }, function (error) {

                    alert('Failed delete ', error);

            });

        }, function (error) {

                alert('Failed delete outer', error);

        });

    };
    
    // Update record AJAX
    /*
    $scope.updatedata = function () {
        $.ajax({
            url: "/Dashboard/update_record",
            data: $scope.register,
            type: "POST",
            dataType: "json",
            success: function (result) {
                $scope.btntext = "Update";
                $scope.register = null;
            },
            error: function (error) {
               alert('Failed update data', error);
            }
        });
    }
    */

    // Update record
$scope.updatedata = function () {

    //   $scope.btntext = "Please Wait..";

    $http({

        method: 'POST',

        url: '/Dashboard/update_record',

        data: $scope.register

    }).success(function (d) {

        $scope.btntext = "Updated";
        $scope.register = null;
        alert(d);
        url: '/Dashboard';

    }).error(function () {

        alert('Failed update data', error);

    });

    };
});