using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GalleryItem : MonoBehaviour
{
    [Header("Target Information")]
    public string targetID = "deer";
    public string targetName = "Deer";

    [Header("Images")]
    public Sprite discoveredImage;
    public Sprite unknownImage;

    [Header("UI")]
    public Image targetImage;
    public TMP_Text targetNameText;

    [Header("Score")]
    public int score = 100;

    void Start()
    {
        UpdateGalleryItem();
    }

    public void UpdateGalleryItem()
    {
        if (CollectionManager.Instance == null)
            return;

        bool discovered =
            CollectionManager.Instance.HasPhotographed(targetID);

        if (discovered)
        {
            // 已经拍摄
            targetImage.sprite = discoveredImage;
            targetNameText.text = targetName;
        }
        else
        {
            // 没有拍摄
            targetImage.sprite = unknownImage;
            targetNameText.text = "UNKNOWN";
        }
    }
}
