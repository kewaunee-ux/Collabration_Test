mergeInto(LibraryManager.library, {
    OpenSceneInNewTab: function(sceneName) {
        var currentURL = window.location.href;
        var baseURL = currentURL.split('?')[0];  // Remove any existing query parameters
        
        // Add or update the scene parameter
        var newURL = baseURL + '?scene=' + UTF8ToString(sceneName);
        
        // Open in new tab
        window.open(newURL, '_blank');
    }
});