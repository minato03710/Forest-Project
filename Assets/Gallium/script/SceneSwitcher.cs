using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GoToForest()
    {
        SceneManager.LoadScene("ForestScene");
    }

    public void GoToGallery()
    {
        SceneManager.LoadScene("GalleryScene");
    }
}
