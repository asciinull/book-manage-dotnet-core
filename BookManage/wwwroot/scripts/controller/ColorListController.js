function ColorListController($scope, $state, $stateParams, $uibModal, BookManageService) {

    function color_items_callback(response) {

        $scope.items_loaded = true;
        if (response.status != 1) {
            $scope.items_message = response.message;
            return;
        }

        $scope.items = response.items;
    }

    function color_count_callback(response) {

        $scope.count_loaded = true;
        if (response.status != 1) {
            $scope.count_message = response.message;
            return;
        }

        $scope.totalCount = response.totalCount;
    }

    function color_disable_callback(response) {

        if (response.status != 1) {
            return;
        }

        $scope.pageChanged();
    }

    $scope.openCreate = function () {

        var modalInstance = $uibModal.open({
            size: 'lg',
            animation: true,
            templateUrl: 'scripts/view/view_color_create.html?v=' + window.releaseNo,
            controller: ColorCreateController,
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
            templateUrl: 'scripts/view/view_color_item.html?v=' + window.releaseNo,
            controller: ColorItemController,
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
            templateUrl: 'scripts/view/view_color_update.html?v=' + window.releaseNo,
            controller: ColorUpdateController,
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

        BookManageService.color_items(request).then(color_items_callback);
    }

    $scope.disable = function (id) {

        BookManageService.color_disable({ id: id }).then(color_disable_callback);
    }

    $scope.refresh = function () {

        {
            var request = {};
            BookManageService.color_count(request).then(color_count_callback);
        }

        {
            var request = {};
            request.pageIndex = $scope.currentPage;
            BookManageService.color_items(request).then(color_items_callback);
        }
    }

    {
        $scope.maxSize = 10;
        $scope.currentPage = 1;
        $scope.pageSize = 20;

        $scope.refresh();
    }

}