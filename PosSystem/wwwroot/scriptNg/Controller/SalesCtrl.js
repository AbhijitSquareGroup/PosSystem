// Define the 'salesController' controller
app.controller('SalesController', ['$scope', function ($scope) {
    // Initialize scope variables
    $scope.selectedCustomerId = null;
    $scope.customerDetails = null;
    $scope.addedProducts = [];
    $scope.discountAmount = 0;
    $scope.grandTotal = 0;

    // Simulated customer data (you can replace this with actual data from your server)
    $scope.customers = [
        { CustomerId: 1, CustomerName: 'Customer 1', CustomerAddress: 'Address 1' },
        { CustomerId: 2, CustomerName: 'Customer 2', CustomerAddress: 'Address 2' },
        // Add more customers as needed
    ];

    // Function to get customer details based on the selected customer
    $scope.getCustomerDetails = function () {
        var customerId = $scope.selectedCustomerId;

        // Simulated customer details (replace with actual data from your server)
        var customer = $scope.customers.find(function (c) {
            return c.CustomerId === customerId;
        });

        $scope.customerDetails = customer;
    };

    // Function to add a product
    $scope.addProduct = function () {
        // Simulated product data (replace with actual data or logic)
        var product = {
            ProductName: 'Product 1',
            ProductPrice: 100,
            Quantity: 1,
            Total: 100,
        };

        $scope.addedProducts.push(product);
        $scope.calculateTotalSale();
    };

    // Function to calculate the total sale
    $scope.calculateTotalSale = function () {
        var totalSale = 0;

        for (var i = 0; i < $scope.addedProducts.length; i++) {
            totalSale += $scope.addedProducts[i].Total;
        }

        $scope.totalSale = totalSale;
        $scope.calculateGrandTotal();
    };

    // Function to calculate the grand total after applying discount
    $scope.calculateGrandTotal = function () {
        var discount = $scope.discountAmount || 0;
        $scope.grandTotal = $scope.totalSale - discount;
    };
}]);
