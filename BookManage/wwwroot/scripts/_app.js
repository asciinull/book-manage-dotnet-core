//Module
var app = angular.module('app', ['ngResource', 'ui.router', 'ui.bootstrap', 'ui.sortable', 'ngCanos']);

//Config
app.config(httpProviderConfig);
app.config(stateProviderConfig);
app.config(urlRouterProviderConfig);

//service
app.service('BookManageService', ['$resource', '$q', BookManageService]);
