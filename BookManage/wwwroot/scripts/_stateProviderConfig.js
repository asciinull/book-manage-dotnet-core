function stateProviderConfig($stateProvider) {

    $stateProvider.state('app', {
        url: '/',
        views: {
            'header': { templateUrl: 'scripts/view/view_header.html?v=' + window.releaseNo, controller: HeaderController },
            'main-menu': { templateUrl: 'scripts/view/view_menu.html?v=' + window.releaseNo},
            'main-body': { template: '<div ui-view></div>' }
        }
    });

    $stateProvider.state('app.welcome', { url: 'welcome', templateUrl: 'scripts/view/view_welcome.html?v=' + window.releaseNo });

    $stateProvider.state('app.the-book-list', { url: 'the-book-list', templateUrl: 'scripts/view/view_the_book_list.html?v=' + window.releaseNo, controller: TheBookListController });

    $stateProvider.state('app.category-list', { url: 'category-list', templateUrl: 'scripts/view/view_category_list.html?v=' + window.releaseNo, controller: CategoryListController });

    $stateProvider.state('app.color-list', { url: 'color-list', templateUrl: 'scripts/view/view_color_list.html?v=' + window.releaseNo, controller: ColorListController });

    $stateProvider.state('app.otherwise', {
        url: '*path',
        templateUrl: 'views/view_404.html?v=' + window.releaseNo
    });
}