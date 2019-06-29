function CategoryCreateController($scope, $convertor, $uibModalInstance, BookManageService) {

    function category_create_callback(response) {

        $scope.waiting = false;

        if (response.status != 1) {
            $scope.message = response.message;
            return;
        }

        $uibModalInstance.close("success");
    }

    $scope.confirmCreate = function () {

        $scope.waiting = true;
        $scope.message = null;

        var request = {};
        var requestItem = request.item = {};
        requestItem.name = $scope.item.name;
        requestItem.description = $scope.item.description;

        BookManageService.category_create(request).then(category_create_callback);
    }
}
