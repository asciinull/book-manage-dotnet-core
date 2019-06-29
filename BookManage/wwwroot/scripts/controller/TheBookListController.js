function TheBookListController($scope, $state, $stateParams, $uibModal, BookManageService) {

    function the_book_items_callback(response) {

        $scope.items_loaded = true;
        if (response.status != 1) {
            $scope.items_message = response.message;
            return;
        }

        $scope.items = response.items;
    }

    function the_book_count_callback(response) {

        $scope.count_loaded = true;
        if (response.status != 1) {
            $scope.count_message = response.message;
            return;
        }

        $scope.totalCount = response.totalCount;
    }

    function the_book_disable_callback(response) {

        if (response.status != 1) {
            return;
        }

        $scope.pageChanged();
    }

    $scope.openCreate = function () {

        var modalInstance = $uibModal.open({
            size: 'lg',
            animation: true,
            templateUrl: 'scripts/view/view_the_book_create.html?v=' + window.releaseNo,
            controller: TheBookCreateController,
            resolve: {
            }
        });

        modalInstance.result.then(function (response) {
            $scope.refresh();
        }, function () {
        });
    }

    $scope.openItem = function (id) {

        var modalInstance = $uibModal.open({
            size: 'lg',
            animation: true,
            templateUrl: 'scripts/view/view_the_book_item.html?v=' + window.releaseNo,
            controller: TheBookItemController,
            resolve: {
                id: function () { return id; }
            }
        });

        modalInstance.result.then(function (response) { }, function () { });
    }

    $scope.openUpdate = function (id) {

        var modalInstance = $uibModal.open({
            size: 'lg',
            animation: true,
            templateUrl: 'scripts/view/view_the_book_update.html?v=' + window.releaseNo,
            controller: TheBookUpdateController,
            resolve: {
                id: function () { return id; }
            }
        });

        modalInstance.result.then(function (response) {
            $scope.refresh();
        }, function () {
        });
    }

    $scope.pageChanged = function () {

        $scope.items_loaded = false;
        $scope.items_message = null;

        var request = {};
        request.pageIndex = $scope.currentPage;

        BookManageService.the_book_items(request).then(the_book_items_callback);
    }

    $scope.disable = function (id) {

        BookManageService.the_book_disable({ id: id }).then(the_book_disable_callback);
    }

    $scope.refresh = function () {

        {
            var request = {};
            BookManageService.the_book_count(request).then(the_book_count_callback);
        }

        {
            var request = {};
            request.pageIndex = $scope.currentPage;
            BookManageService.the_book_items(request).then(the_book_items_callback);
        }
    }

    {
        $scope.maxSize = 10;
        $scope.currentPage = 1;
        $scope.pageSize = 20;

        $scope.refresh();
    }

}