app.controller('ProductController', function ($scope, $http) {
    // Initialize products array
    $scope.products = [];

    $scope.newProduct = { ProductId: 0, Name: '', Description: '', Price:'',BrandId: 0 }

    $scope.save = function() {
        var data = $scope.newProduct;
        //console.log(data);
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
                console.log(response.data);
                $scope.loadProducts();
            });
    };

    // Function to edit an existing product
    $scope.editProduct = function (product) {
        $http.put('/api/products/' + product.Id, product)
            .then(function (response) {
                // Refresh the products list after updating
                $scope.loadProducts();
            });
    };

    // Function to load products from the API
    $scope.loadProducts = function () {
        $http.get('/api/products')
            .then(function (response) {
                $scope.products = response.data;
            });
    };
});
