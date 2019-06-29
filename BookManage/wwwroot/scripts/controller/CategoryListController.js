function CategoryListController($scope, $state, $stateParams, $uibModal, BookManageService) {

    function category_items_callback(response) {

        $scope.items_loaded = true;
        if (response.status != 1) {
            $scope.items_message = response.message;
            return;
        }

        $scope.items = response.items;
    }

    function category_count_callback(response) {

        $scope.count_loaded = true;
        if (response.status != 1) {
            $scope.count_message = response.message;
            return;
        }

        $scope.totalCount = response.totalCount;
    }

    function category_disable_callback(response) {

        if (response.status != 1) {
            return;
        }

        $scope.pageChanged();
    }

    $scope.openCreate = function () {

        var modalInstance = $uibModal.open({
            size: 'lg',
            animation: true,
            templateUrl: 'scripts/view/view_category_create.html?v=' + window.releaseNo,
            controller: CategoryCreateController,
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
            templateUrl: 'scripts/view/view_category_item.html?v=' + window.releaseNo,
            controller: CategoryItemController,
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
            templateUrl: 'scripts/view/view_category_update.html?v=' + window.releaseNo,
            controller: CategoryUpdateController,
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

        BookManageService.category_items(request).then(category_items_callback);
    }

    $scope.disable = function (id) {

        BookManageService.category_disable({ id: id }).then(category_disable_callback);
    }

    $scope.refresh = function () {

        {
            var request = {};
            BookManageService.category_count(request).then(category_count_callback);
        }

        {
            var request = {};
            request.pageIndex = $scope.currentPage;
            BookManageService.category_items(request).then(category_items_callback);
        }
    }

    {
        $scope.maxSize = 10;
        $scope.currentPage = 1;
        $scope.pageSize = 20;

        $scope.refresh();
    }

}