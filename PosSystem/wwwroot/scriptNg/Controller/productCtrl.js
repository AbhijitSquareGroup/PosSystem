app.controller('ProductController', function ($scope, $http) {
    // Initialize products array
    $scope.products = [];

    $scope.newProduct = { ProductId: 0, Name: '', Description: '', Price:'',BrandId: 0 }

    $scope.save = function() {
        var data = $scope.Product;
        $scope.createProduct(data);
    }


    //service

    // Load products from the API
    $http.get('/product/CreateGet')
        .then(function (response) {
            $scope.products = response.data;
        });

    //// Load products from the API
    //$http.get('/Brand/Getall')
    //    .then(function (response) {
    //        $scope.brands = response.data;
    //    });

    // Function to create a new product
    $scope.createProduct = function (product) {
        $http.post('/product/CreatePost', product)
            .then(function (response) {
                $scope.loadProducts();
            });
    };
    $scope.loadBrands = function () {
        // Make an HTTP GET request to fetch brands from the server
        $http.get('/brand/GetAllBrands') // Replace with the actual API endpoint for fetching brands
            .then(function (response) {
                // Update the brands list when the data is received
                $scope.brands = response.data;
            });
    };
    $scope.loadBrands();

    // Function to edit an existing product
    $scope.editProduct = function (product) {
        $http.put('/product/' + product.Id, product)
            .then(function (response) {
                // Refresh the products list after updating
                $scope.loadProducts();
            });
    };

    // Function to load products from the API
    $scope.loadProducts = function () {
        $http.get('/Product/ProductList')
            .then(function (response) {
                console.log(response.data);
                $scope.products = response.data;
            });
    };
    $scope.loadProducts();
});
