mergeInto(LibraryManager.library, {
    OpenSceneInNewTab: function(sceneName) {
        var currentURL = window.location.href;
        var baseURL = currentURL.split('?')[0];
        var newURL = baseURL + '?scene=' + UTF8ToString(sceneName);
        window.open(newURL, '_blank');
    },

    GetURLParameter: function(parameterName) {
        var paramName = UTF8ToString(parameterName);
        var urlParams = new URLSearchParams(window.location.search);
        var paramValue = urlParams.get(paramName);
        if (paramValue === null) return "";
        
        var bufferSize = lengthBytesUTF8(paramValue) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(paramValue, buffer, bufferSize);
        return buffer;
    },
    
    OpenURLInNewTab: function(url) {
        window.open(UTF8ToString(url), '_blank');
    },

    DownloadFile: function(url, filename) {
        var link = document.createElement('a');
        link.download = UTF8ToString(filename);
        link.href = UTF8ToString(url);
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    },

    EnterFullscreen: function() {
        if (document.documentElement.requestFullscreen) {
            document.documentElement.requestFullscreen();
        } else if (document.documentElement.mozRequestFullScreen) { // Firefox
            document.documentElement.mozRequestFullScreen();
        } else if (document.documentElement.webkitRequestFullscreen) { // Chrome, Safari and Opera
            document.documentElement.webkitRequestFullscreen();
        } else if (document.documentElement.msRequestFullscreen) { // IE/Edge
            document.documentElement.msRequestFullscreen();
        }
    },
    
    ExitFullscreen: function() {
        if (document.exitFullscreen) {
            document.exitFullscreen();
        } else if (document.mozCancelFullScreen) { // Firefox
            document.mozCancelFullScreen();
        } else if (document.webkitExitFullscreen) { // Chrome, Safari and Opera
            document.webkitExitFullscreen();
        } else if (document.msExitFullscreen) { // IE/Edge
            document.msExitFullscreen();
        }
    },
    
    IsInFullscreen: function() {
        var isInFullScreen = 
            (document.fullscreenElement && document.fullscreenElement !== null) ||
            (document.webkitFullscreenElement && document.webkitFullscreenElement !== null) ||
            (document.mozFullScreenElement && document.mozFullScreenElement !== null) ||
            (document.msFullscreenElement && document.msFullscreenElement !== null);
            
        return isInFullScreen;
    },

    CloseCurrentTab: function(confirm) {
        if (!confirm || confirm && window.confirm('Close this tab?')) {
            try {
                window.close();
                if (window.opener) {
                    window.opener = null;
                    window.open('', '_self').close();
                }
            } catch (e) {
                console.log('Failed to close tab:', e);
            }
        }
    }
});