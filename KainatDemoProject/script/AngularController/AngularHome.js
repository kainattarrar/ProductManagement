var app = angular.module('homeapp', []);

app.controller("LoginController", function ($scope, $http) {

    $scope.btntext = "Login";

    $scope.login = function () {


        $http({
            method: "POST",
            url: "/Login/userLogin",
            headers: { "Content-Type": "Application/json;charset=utf-8" },
            data: $scope.user

        }).then(function (response) {

            if (response.data == 1) {
                window.location.href = '/Dashboard';

            }
            else {
                alert("Invaild credentials");
            }

            $scope.user = null;
        }).error(function () {

        alert("Failed");

        });
    }
    $scope.login_ajax = function () {
        console.log("called");

        $http({

            method: "POST",

            url: '/Login/userlogin',

            data: $scope.user

        }).success(function (d) {

            $scope.btntext = 'Login';

            if (d == 1) {

                window.location.href = '/Login/dashboard';

            }

            else {

                alert(d);

            }

            $scope.user = null;

        }).error(function () {

            alert('failed');

        })

    }



})