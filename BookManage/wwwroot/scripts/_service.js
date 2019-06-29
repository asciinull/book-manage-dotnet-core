function BookManageService($resource, $q) {

    function process(result, d){
        if (result.status == 401) {
            localStorage["token"] = "";
            window.location.href = window.location.href.replace(window.location.origin, window.location.origin + '/account/login')
        } else {
            d.reject(result);
        }
    }

    var resource = $resource('api', {}, {

        the_book_items: { method: 'POST', url: 'api/the-book/items' },
        the_book_item: { method: 'POST', url: 'api/the-book/item' },
        the_book_basic: { method: 'POST', url: 'api/the-book/basic' },
        the_book_count: { method: 'POST', url: 'api/the-book/count' },
        the_book_update: { method: 'POST', url: 'api/the-book/update' },
        the_book_enable: { method: 'POST', url: 'api/the-book/enable' },
        the_book_disable: { method: 'POST', url: 'api/the-book/disable' },
        the_book_create: { method: 'POST', url: 'api/the-book/create' },
        the_book_disable: { method: 'POST', url: 'api/the-book/disable' },

        category_items: { method: 'POST', url: 'api/category/items' },
        category_item: { method: 'POST', url: 'api/category/item' },
        category_basic: { method: 'POST', url: 'api/category/basic' },
        category_count: { method: 'POST', url: 'api/category/count' },
        category_update: { method: 'POST', url: 'api/category/update' },
        category_enable: { method: 'POST', url: 'api/category/enable' },
        category_disable: { method: 'POST', url: 'api/category/disable' },
        category_create: { method: 'POST', url: 'api/category/create' },
        category_disable: { method: 'POST', url: 'api/category/disable' },

        color_items: { method: 'POST', url: 'api/color/items' },
        color_item: { method: 'POST', url: 'api/color/item' },
        color_basic: { method: 'POST', url: 'api/color/basic' },
        color_count: { method: 'POST', url: 'api/color/count' },
        color_update: { method: 'POST', url: 'api/color/update' },
        color_enable: { method: 'POST', url: 'api/color/enable' },
        color_disable: { method: 'POST', url: 'api/color/disable' },
        color_create: { method: 'POST', url: 'api/color/create' },
        color_disable: { method: 'POST', url: 'api/color/disable' },

        meta_category_items: { method: 'POST', url: 'api/meta-category/items' },
        meta_category_selected_item: { method: 'POST', url: 'api/meta-category/selected-item' },
        meta_category_selected_items: { method: 'POST', url: 'api/meta-category/selected-items' },

        meta_color_items: { method: 'POST', url: 'api/meta-color/items' },
        meta_color_selected_item: { method: 'POST', url: 'api/meta-color/selected-item' },
        meta_color_selected_items: { method: 'POST', url: 'api/meta-color/selected-items' },

        user_profile: { method: 'POST', url: 'api/user/profile' }
    });

    return {

        the_book_items: function (request) { var d = $q.defer(); resource.the_book_items({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        the_book_item: function (request) { var d = $q.defer(); resource.the_book_item({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        the_book_basic: function (request) { var d = $q.defer(); resource.the_book_basic({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        the_book_update: function (request) { var d = $q.defer(); resource.the_book_update({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        the_book_count: function (request) { var d = $q.defer(); resource.the_book_count({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        the_book_enable: function (request) { var d = $q.defer(); resource.the_book_enable({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        the_book_disable: function (request) { var d = $q.defer(); resource.the_book_disable({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        the_book_create: function (request) { var d = $q.defer(); resource.the_book_create({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        the_book_disable: function (request) { var d = $q.defer(); resource.the_book_disable({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },

        category_items: function (request) { var d = $q.defer(); resource.category_items({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        category_item: function (request) { var d = $q.defer(); resource.category_item({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        category_basic: function (request) { var d = $q.defer(); resource.category_basic({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        category_update: function (request) { var d = $q.defer(); resource.category_update({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        category_count: function (request) { var d = $q.defer(); resource.category_count({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        category_enable: function (request) { var d = $q.defer(); resource.category_enable({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        category_disable: function (request) { var d = $q.defer(); resource.category_disable({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        category_create: function (request) { var d = $q.defer(); resource.category_create({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        category_disable: function (request) { var d = $q.defer(); resource.category_disable({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },

        color_items: function (request) { var d = $q.defer(); resource.color_items({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        color_item: function (request) { var d = $q.defer(); resource.color_item({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        color_basic: function (request) { var d = $q.defer(); resource.color_basic({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        color_update: function (request) { var d = $q.defer(); resource.color_update({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        color_count: function (request) { var d = $q.defer(); resource.color_count({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        color_enable: function (request) { var d = $q.defer(); resource.color_enable({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        color_disable: function (request) { var d = $q.defer(); resource.color_disable({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        color_create: function (request) { var d = $q.defer(); resource.color_create({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        color_disable: function (request) { var d = $q.defer(); resource.color_disable({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },

        meta_category_items: function (request) { var d = $q.defer(); resource.meta_category_items({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        meta_category_selected_item: function (request) { var d = $q.defer(); resource.meta_category_selected_item({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        meta_category_selected_items: function (request) { var d = $q.defer(); resource.meta_category_selected_items({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },

        meta_color_items: function (request) { var d = $q.defer(); resource.meta_color_items({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        meta_color_selected_item: function (request) { var d = $q.defer(); resource.meta_color_selected_item({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        meta_color_selected_items: function (request) { var d = $q.defer(); resource.meta_color_selected_items({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },

        user_profile: function (request) { var d = $q.defer(); resource.user_profile({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; }
    }
}
