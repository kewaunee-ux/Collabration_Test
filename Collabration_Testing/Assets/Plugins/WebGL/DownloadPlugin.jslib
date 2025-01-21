mergeInto(LibraryManager.library, {
    DownloadFile: function(url, filename) {
        var link = document.createElement('a');
        link.download = UTF8ToString(filename);
        link.href = UTF8ToString(url);
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    }
});