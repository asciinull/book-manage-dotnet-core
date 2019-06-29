function ColorCreateController($scope, $convertor, $uibModalInstance, BookManageService) {

    function color_create_callback(response) {

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
        requestItem.colorId = $scope.item.colorId;
        requestItem.colorName = $scope.item.colorName;

        BookManageService.color_create(request).then(color_create_callback);
    }
}
