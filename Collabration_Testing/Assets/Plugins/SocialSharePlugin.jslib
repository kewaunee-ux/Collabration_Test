mergeInto(LibraryManager.library, {
    ShareToLinkedIn: function(url, text) {
        var shareUrl = UTF8ToString(url);
        var shareText = UTF8ToString(text);
        var linkedInUrl = 'https://www.linkedin.com/sharing/share-offsite/?url=' + encodeURIComponent(shareUrl);
        window.open(linkedInUrl, '_blank', 'width=600,height=600');
    },

    ShareToFacebook: function(url, text) {
        var shareUrl = UTF8ToString(url);
        var shareText = UTF8ToString(text);
        var facebookUrl = 'https://www.facebook.com/sharer/sharer.php?u=' + encodeURIComponent(shareUrl);
        window.open(facebookUrl, '_blank', 'width=600,height=600');
    },

    ShareToTwitter: function(url, text) {
        var shareUrl = UTF8ToString(url);
        var shareText = UTF8ToString(text);
        var twitterUrl = 'https://twitter.com/intent/tweet?url=' + encodeURIComponent(shareUrl) + 
                        '&text=' + encodeURIComponent(shareText);
        window.open(twitterUrl, '_blank', 'width=600,height=600');
    }
});