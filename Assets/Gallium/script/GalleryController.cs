using UnityEngine;

public class GalleryController : MonoBehaviour
{
    [Header("Gallery")]
    public GameObject galleryPanel;

    private bool galleryOpen = false;

    void Start()
    {
        CloseGallery();
    }

    public void OpenGallery()
    {
        galleryOpen = true;

        galleryPanel.SetActive(true);

        // ‘›Õ£”Œœ∑
        Time.timeScale = 0f;

        Debug.Log("Gallery Opened");
    }

    public void CloseGallery()
    {
        galleryOpen = false;

        galleryPanel.SetActive(false);

        // ª÷∏¥”Œœ∑
        Time.timeScale = 1f;

        Debug.Log("Gallery Closed");
    }
}
