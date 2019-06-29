function CategoryUpdateController($scope, $convertor, $uibModalInstance, id, BookManageService) {

    $scope.id = id;

    function category_basic_callback(response) {

        $scope.loaded = true;
        if (response.status != 1) {
            return;
        }

        $scope.item = response.item;
    }

    function category_update_callback(response) {

        $scope.waiting = false;

        if (response.status != 1) {
            $scope.message = response.message;
            return;
        }

        $uibModalInstance.close("success");
    }

    $scope.confirmUpdate = function () {

        $scope.waiting = true;
        $scope.message = null;

        var request = {};
        request.id = $scope.item.id;
        var requestItem = request.item = {};
        requestItem.name = $scope.item.name;
        requestItem.description = $scope.item.description;

        BookManageService.category_update(request).then(category_update_callback)
    }

    BookManageService.category_basic({ id: $scope.id }).then(category_basic_callback);
}
