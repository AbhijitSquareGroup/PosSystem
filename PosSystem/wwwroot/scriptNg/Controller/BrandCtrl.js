// BrandController.js
app.controller('BrandController', function ($scope, $http) {
    $scope.brands = []; // Initialize brands array

    // Function to load brands
    $scope.loadBrands = function () {
        // Make an HTTP GET request to fetch brands from the server
        $http.get('/brand/GetBrands') // Replace with the actual API endpoint for fetching brands
            .then(function (response) {
                // Update the brands list when the data is received
                $scope.brands = response.data;
                console.log(response.data)
            });
    };

    // Call loadBrands initially to load brands when the page loads
    $scope.loadBrands();
});
