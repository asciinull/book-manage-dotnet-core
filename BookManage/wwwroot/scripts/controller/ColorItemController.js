function ColorItemController($scope, $uibModalInstance, id, BookManageService) {

    $scope.id = id;

    function color_item_callback(response) {

        $scope.loaded = true;
        if (response.status != 1) {
            return;
        }

        $scope.item = response.item;
    }

    {
        var request = {};
        request.id = $scope.id;

        BookManageService.color_item(request).then(color_item_callback);
    }

}