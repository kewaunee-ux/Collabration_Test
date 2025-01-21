using UnityEngine;
using UnityEngine.UIElements;
using System.Runtime.InteropServices;

public class SceneOpener : MonoBehaviour
{
    [SerializeField]
    private string sceneName = ""; // Name of the scene to open

/*    [SerializeField]
    private Button openButton; // Reference to the UI button*/

    // Import JavaScript function
    [DllImport("__Internal")]
    private static extern void OpenSceneInNewTab(string sceneName);

    public void OpenScene()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            // Use the JavaScript plugin in WebGL builds
            OpenSceneInNewTab(sceneName);
#else
        // For testing in editor
        Debug.Log("Would open scene: " + sceneName);
        // Optionally load the scene directly in editor
        // UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
#endif
    }
}