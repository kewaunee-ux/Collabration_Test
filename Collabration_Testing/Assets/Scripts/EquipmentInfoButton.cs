using UnityEngine;

public class EquipmentInfoButton : MonoBehaviour
{
    [SerializeField] private string equipmentId;
    private DocumentViewer documentViewer;

    private void Awake()
    {
        // Use FindFirstObjectByType instead of FindObjectOfType
        documentViewer = Object.FindFirstObjectByType<DocumentViewer>();

        if (documentViewer == null)
        {
            Debug.LogError("DocumentViewer not found in scene!");
        }
    }

    public void OnInfoButtonClick()
    {
        documentViewer?.ViewDocument(equipmentId);
    }

    public void OnDownloadButtonClick()
    {
        documentViewer?.DownloadDocument(equipmentId);
    }
}
