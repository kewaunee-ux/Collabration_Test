using UnityEngine;
using System.Runtime.InteropServices;


public class DocumentViewer : MonoBehaviour
{
    [System.Serializable]
    public class DocumentInfo
    {
        public string equipmentId;
        public string documentName;
        public string oneDriveViewLink;
        public string oneDriveDownloadLink;
    }

    [SerializeField] private DocumentInfo[] documents;

    // JavaScript interface
    [DllImport("__Internal")]
    private static extern void OpenURLInNewTab(string url);

    [DllImport("__Internal")]
    private static extern void DownloadFile(string url, string fileName);

    public void ViewDocument(string equipmentId)
    {
        var doc = System.Array.Find(documents, d => d.equipmentId == equipmentId);
        if (doc != null)
        {
#if UNITY_WEBGL && !UNITY_EDITOR
                OpenURLInNewTab(doc.oneDriveViewLink);
#else
            Application.OpenURL(doc.oneDriveViewLink);
#endif
        }
        else
        {
            Debug.LogError($"No document found for equipment ID: {equipmentId}");
        }
    }

    public void DownloadDocument(string equipmentId)
    {
        var doc = System.Array.Find(documents, d => d.equipmentId == equipmentId);
        if (doc != null)
        {
            string fileName = $"{doc.documentName}.pdf";  // Assume PDF, adjust as needed
#if UNITY_WEBGL && !UNITY_EDITOR
                DownloadFile(doc.oneDriveDownloadLink, fileName);
#else
            Application.OpenURL(doc.oneDriveDownloadLink);
#endif
        }
        else
        {
            Debug.LogError($"No document found for equipment ID: {equipmentId}");
        }
    }
}
