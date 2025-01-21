mergeInto(LibraryManager.library, {
    OpenURLInNewTab: function(url) {
        window.open(UTF8ToString(url), '_blank', 'noopener,noreferrer');
    },
    
    DownloadFile: function(url, fileName) {
        var link = document.createElement('a');
        link.href = UTF8ToString(url);
        link.download = UTF8ToString(fileName);
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    }
});