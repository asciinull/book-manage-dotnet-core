function TheBookItemController($scope, $uibModalInstance, id, BookManageService) {

    $scope.id = id;

    function the_book_item_callback(response) {

        $scope.loaded = true;
        if (response.status != 1) {
            return;
        }

        $scope.item = response.item;
    }

    {
        var request = {};
        request.id = $scope.id;

        BookManageService.the_book_item(request).then(the_book_item_callback);
    }

}