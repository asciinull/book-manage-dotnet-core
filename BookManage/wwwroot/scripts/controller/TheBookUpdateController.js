function TheBookUpdateController($scope, $convertor, $uibModalInstance, id, BookManageService) {

    $scope.id = id;

    function the_book_basic_callback(response) {

        $scope.loaded = true;
        if (response.status != 1) {
            return;
        }

        $scope.item = response.item;
        $convertor.setSelected($scope, null, $scope.item.categoryIds, 'categoryIds_selection', 'categoryIds_keys', 'name');
    }

    function the_book_update_callback(response) {

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
        requestItem.title = $scope.item.title;
        requestItem.categoryIds = $convertor.toSelected($scope.categoryIds_selection, 'name');
        requestItem.colorId = $scope.item.colorId;

        BookManageService.the_book_update(request).then(the_book_update_callback)
    }

    BookManageService.meta_category_items({}).then(categoryIds_meta_category_items_callback);

    function categoryIds_meta_category_items_callback(response) {
        if (response.status != 1) {
            return;
        }
        $convertor.setSelected($scope, response.items, null, 'categoryIds_selection', 'categoryIds_keys', 'categoryIds');
    }

    BookManageService.meta_color_items({}).then(colorId_meta_color_items_callback);

    function colorId_meta_color_items_callback(response) {
        if (response.status != 1) {
            return;
        }
        $convertor.setSelected($scope, response.items, null, 'colorId_selection', 'colorId_keys', 'colorId');
    }

    BookManageService.the_book_basic({ id: $scope.id }).then(the_book_basic_callback);
}
