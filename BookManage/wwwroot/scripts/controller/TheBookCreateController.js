function TheBookCreateController($scope, $convertor, $uibModalInstance, BookManageService) {

    function the_book_create_callback(response) {

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
        requestItem.title = $scope.item.title;
        requestItem.categoryIds = $convertor.toSelected($scope.categoryIds_selection, 'name');
        requestItem.colorId = $scope.item.colorId;

        BookManageService.the_book_create(request).then(the_book_create_callback);
    }

    BookManageService.meta_category_items({}).then(categoryIds_meta_category_items_callback);

    function categoryIds_meta_category_items_callback(response) {
        if (response.status != 1) {
            return;
        }
        $scope.categoryIds_selection = response.items;
    }

    BookManageService.meta_color_items({}).then(colorId_meta_color_items_callback);

    function colorId_meta_color_items_callback(response) {
        if (response.status != 1) {
            return;
        }
        $scope.colorId_selection = response.items;
    }
}
