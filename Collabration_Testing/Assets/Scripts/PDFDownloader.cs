using UnityEngine;
using System.Runtime.InteropServices;

public class PDFDownloader : MonoBehaviour
{
    // Your Google Drive PDF link
    // Note: Make sure this is a direct download link, not a view link
    [SerializeField]
    private string pdfUrl = "YOUR_GOOGLE_DRIVE_DOWNLOAD_LINK";

    // JavaScript plugin method to handle downloads in WebGL
    [DllImport("__Internal")]
    private static extern void DownloadFile(string url, string filename);

    // Method to trigger when button is clicked
    public void DownloadPDF()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            // Convert Google Drive viewing URL to direct download URL if needed
            string directUrl = ConvertToDirectDownloadLink(pdfUrl);
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
}
