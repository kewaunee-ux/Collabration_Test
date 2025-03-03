using UnityEngine;
using System.Runtime.InteropServices;

public class SocialShare : MonoBehaviour
{
    // URL to share - set this to your virtual showroom's URL
    [SerializeField]
    private string shareUrl = "https://your-virtual-showroom-url.com";

    // Optional: Text to share
    [SerializeField]
    private string shareText = "Check out Kewaunee's Virtual Showroom!";

    // Import JavaScript functions
    [DllImport("__Internal")]
    private static extern void ShareToLinkedIn(string url, string text);

    [DllImport("__Internal")]
    private static extern void ShareToFacebook(string url, string text);

    [DllImport("__Internal")]
    private static extern void ShareToTwitter(string url, string text);

    // Call these methods from your UI buttons
    public void ShareOnLinkedIn()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            ShareToLinkedIn(shareUrl, shareText);
#else
        Debug.Log("LinkedIn sharing only works in WebGL build");
#endif
    }

    public void ShareOnFacebook()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            ShareToFacebook(shareUrl, shareText);
#else
        Debug.Log("Facebook sharing only works in WebGL build");
#endif
    }

    public void ShareOnTwitter()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            ShareToTwitter(shareUrl, shareText);
#else
        Debug.Log("Twitter sharing only works in WebGL build");
#endif
    }
}
