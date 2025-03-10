using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class SceneOpener : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private string videoURL;
    #region Java Script Functions

    // Import JavaScript functions
    [DllImport("__Internal")]
    private static extern void OpenSceneInNewTab(string sceneName);

    [DllImport("__Internal")]
    private static extern void OpenURLInNewTab(string url);

    [DllImport("__Internal")]
    private static extern void DownloadFile(string url, string filename);

    [DllImport("__Internal")]
    private static extern string GetURLParameter(string parameterName);

    // Import JavaScript functions
    [DllImport("__Internal")]
    private static extern void EnterFullscreen();

    [DllImport("__Internal")]
    private static extern void ExitFullscreen();

    [DllImport("__Internal")]
    private static extern bool IsInFullscreen();

    [DllImport("__Internal")]
    private static extern void CloseCurrentTab(bool confirm);

    #endregion

    private bool isFullscreen = false;
    [SerializeField] private bool useConfirmation = true;

    void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            // Get the scene parameter from URL
            string sceneToLoad = GetURLParameter("scene");
            
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                // Load the specified scene
                SceneManager.LoadScene(sceneToLoad);
            }
#endif
    }

    private void Awake()
    {
        if (videoPlayer)
        {
            videoPlayer.url = videoURL;
            videoPlayer.playOnAwake = false;
            videoPlayer.Prepare();
            videoPlayer.prepareCompleted += OnVideoPrepared;
        }
    }

    public void OnVideoPrepared(VideoPlayer source)
    {
        videoPlayer.Play();
    }

    public void OpenScene(string sceneName)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            OpenSceneInNewTab(sceneName);
#else
        Debug.Log("Would open scene: " + sceneName);
#endif
    }

    public void OpenURL(string urlToOpen)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            OpenURLInNewTab(urlToOpen);
#else
        Debug.Log("Would open URL: " + urlToOpen);
        Application.OpenURL(urlToOpen);
#endif
    }

    // Method to trigger when button is clicked
    public void DownloadFile(string fileUrl)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            // Convert Google Drive viewing URL to direct download URL if needed
            string directUrl = ConvertToDirectDownloadLink(fileUrl);
            // Call JavaScript function to handle download
            DownloadFile(directUrl, "downloaded_document.pdf");
#else
        Debug.Log("PDF download is only supported in WebGL builds");
#endif
    }

    private string ConvertToDirectDownloadLink(string driveUrl)
    {
        // If the URL is already in the direct download format, return it
        if (driveUrl.Contains("export=download"))
            return driveUrl;

        // Convert viewing URL to direct download URL
        // Example: https://drive.google.com/file/d/FILE_ID/view?usp=sharing
        // to: https://drive.google.com/uc?export=download&id=FILE_ID
        if (driveUrl.Contains("/file/d/"))
        {
            string fileId = driveUrl.Split(new string[] { "/file/d/" }, System.StringSplitOptions.None)[1];
            fileId = fileId.Split('/')[0];
            return $"https://drive.google.com/uc?export=download&id={fileId}";
        }

        return driveUrl;
    }

    public void ToggleFullscreen()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            if (IsInFullscreen())
            {
                ExitFullscreen();
                isFullscreen = false;
            }
            else
            {
                EnterFullscreen();
                isFullscreen = true;
            }
#else
        Debug.Log("Fullscreen toggle only works in WebGL build");
#endif
    }

    public void CloseTab()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            CloseCurrentTab(useConfirmation);
#else
        Debug.Log("Tab closing works only in WebGL build");
#endif
    }
}