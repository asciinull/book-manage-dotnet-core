function HeaderController($scope, BookManageService) {

    function user_profile_callback(response) {
        $scope.userName = response.userName;
    }

    BookManageService.user_profile({}).then(user_profile_callback);
}