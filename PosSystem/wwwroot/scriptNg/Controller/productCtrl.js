
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
app.controller("Table", function ($scope) {
    var employees = [
        { firstName: "Mr.", LastName: "Bean", gender: "Male", salary: "589000" },
        { firstName: "Mr.", LastName: "Karxon", gender: "Female", salary: "25000" },
        { firstName: "Mr.", LastName: "Abhijit", gender: "Male", salary: "15236987" },
    ];
    $scope.employeeList = employees;
    var countries = [
        {
            name: "UK",
            cities: [
                { name: "London" },
                { name: "Manchester" },
                { name: "Birmingham" },
            ]
        },
        {
            name: "Bangladesh",
            cities: [
                { name: "Dhaka" },
                { name: "Khulna" },
                { name: "Barisal" },
            ]
        },
        {
            name: "India",
            cities: [
                { name: "Kolkata" },
                { name: "Chennai" },
                { name: "Delhi" },
            ]
        },
    ];
    $scope.countryList = countries;
    var technologies = [
        { name: "c#", like: 0, dislike: 0 },
        { name: "Asp.Net", like: 0, dislike: 0 },
        { name: "Java", like: 0, dislike: 0 },
    ];
    $scope.technologyList = technologies;
    $scope.incrementLikes = function (technology) {
        technology.like++;
    }

    $scope.incrementDislikes = function (technology) {
        technology.dislike++;
    }

    $scope.decrementLikes = function (technology) {
        if (technology.like > 0) {
            technology.like--;
        }
    }

    $scope.decrementDislikes = function (technology) {
        if (technology.dislike > 0) {
            technology.dislike--;
        }
    }
    var students = [
        { name: "Ben", dateOfBirth: new Date("november 23,1980"), gender: "Male", salary: 55000 },
        { name: "Beniiiiii", dateOfBirth: new Date("november 29,1900"), gender: "Male", salary: 65000 },
    ];
    $scope.studentList = students; 
    $scope.rowlimit = 1;

});