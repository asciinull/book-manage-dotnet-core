function httpProviderConfig($httpProvider) {

    if (localStorage["token"]) {
        $httpProvider.defaults.headers.common = {'authorization': 'Bearer ' + localStorage['token']};
    }
}