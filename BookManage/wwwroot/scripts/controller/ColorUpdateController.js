function ColorUpdateController($scope, $convertor, $uibModalInstance, id, BookManageService) {

    $scope.id = id;

    function color_basic_callback(response) {

        $scope.loaded = true;
        if (response.status != 1) {
            return;
        }

        $scope.item = response.item;
    }

    function color_update_callback(response) {

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
        requestItem.colorId = $scope.item.colorId;
        requestItem.colorName = $scope.item.colorName;

        BookManageService.color_update(request).then(color_update_callback)
    }

    BookManageService.color_basic({ id: $scope.id }).then(color_basic_callback);
}
