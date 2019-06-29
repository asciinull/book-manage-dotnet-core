function CategoryItemController($scope, $uibModalInstance, id, BookManageService) {

    $scope.id = id;

    function category_item_callback(response) {

        $scope.loaded = true;
        if (response.status != 1) {
            return;
        }

        $scope.item = response.item;
    }

    {
        var request = {};
        request.id = $scope.id;

        BookManageService.category_item(request).then(category_item_callback);
    }

}