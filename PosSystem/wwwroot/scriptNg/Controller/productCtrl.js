app.controller('ProductController', function ($scope, $http) {
    // Initialize products array
    $scope.products = [];
    $scope.editMode = false;
    $scope.Product = { ProductId: 0, Name: '', Description: '', Price: '', BrandId: 0 }
    $scope.newProduct = { ProductId: 0, Name: '', Description: '', Price:'',BrandId: 0 }

    $scope.save = function() {
        var data = $scope.Product;
        if (data.ProductId == 0) {
            $scope.createProduct(data);
        }
        else {
            $scope.editProduct(data);
        }
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
                if (response.statusCode == 200) {
                    $scope.loadProducts();
                    $scope.newProduct = { ProductId: 0, Name: '', Description: '', Price: '', BrandId: 0 }
                }
                else {

                }
                
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
        $http.put('/product/ProductEdit/',product) // Ensure the correct URL
            .then(function (response) {
                if (response.status === 200) {
                    // Success: Product updated successfully
                    $scope.loadProducts();
                } else {
                    // Handle other HTTP status codes (e.g., 400, 404, 500) as needed
                    console.error("Error updating product:", response.data.Message);
                }
            })
            .catch(function (error) {
                // Handle network errors or other exceptions
                console.error("An error occurred:", error);
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

    $scope.edit = function (product) {

        $scope.Product.ProductId = product.productId;
        $scope.Product.Name = product.name;
        $scope.Product.Description = product.description;
        $scope.Product.Price = product.price;
        $scope.Product.BrandId = product.brandId;
    };

    //$scope.deleteProduct = function (product) {
       /* var confirmDelete = window.confirm("Are you sure you want to delete this product?");
        
        if (confirmDelete) {
            var obj = {
                ProductId: product.productId,
                Name: product.name,
                Description: product.description,
                Price: product.price,
                BrandId: product.brandId
            }
            // The user clicked "OK" in the confirmation dialog
            $http.delete('/Product/ProductDelete/' + obj)
                .then(function (response) {
                    if (response.status === 200) {
                        alert("Product deleted successfully.");
                        $scope.loadProducts(); // Reload the product list
                    } else {
                        alert("Failed to delete the product.");
                    }
                })
                .catch(function (error) {
                    console.error("An error occurred:", error);
                });
        } else {
            // The user clicked "Cancel" or closed the confirmation dialog
            // You can add additional handling here if needed
        }*/
        $scope.deleteProduct = function (productId) {
            var confirmDelete = window.confirm("Are you sure you want to delete this product?");

            if (confirmDelete) {
                // The user clicked "OK" in the confirmation dialog
                $http.delete('/Product/ProductDelete/'+productId)
                    .then(function (response) {
                        if (response.status === 200) {
                            alert("Product deleted successfully.");
                            $scope.loadProducts(); // Reload the product list
                        } else {
                            alert("Failed to delete the product.");
                        }
                    })
                    .catch(function (error) {
                        console.error("An error occurred:", error);
                    });
            } else {
                // The user clicked "Cancel" or closed the confirmation dialog
                // You can add additional handling here if needed
            }
    };

});
