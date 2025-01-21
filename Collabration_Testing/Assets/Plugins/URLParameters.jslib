mergeInto(LibraryManager.library, {
    GetURLParameter: function(parameterName) {
        var paramName = UTF8ToString(parameterName);
        var urlParams = new URLSearchParams(window.location.search);
        var paramValue = urlParams.get(paramName);
        if (paramValue === null) return "";
        
        var bufferSize = lengthBytesUTF8(paramValue) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(paramValue, buffer, bufferSize);
        return buffer;
    }
});