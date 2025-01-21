using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class SceneParameterLoader : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string GetURLParameter(string parameterName);

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
}