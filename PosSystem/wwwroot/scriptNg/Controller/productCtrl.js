
app.controller('productCtrl', function ($scope) {
    $scope.firstName = "Abhijit";
    $scope.lastName = "Gosh";
});
app.controller("myController", function ($scope) {
    var employee = {
        firstName: "",
        lastName: "",
        gender: ""
    };
    $scope.employee = employee;
    $scope.message = "Angular Tutorial";
    $scope.mssg = "Hello Angular";
});
/*app.controller("Controller", Function($scope){
    $scope.mssg = "Hello Angular";
});*/