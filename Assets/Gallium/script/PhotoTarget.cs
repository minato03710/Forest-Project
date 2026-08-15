using UnityEngine;

public class PhotoTarget : MonoBehaviour
{
    [Header("Target Information")]
    public string targetID = "deer";
    public string targetName = "Deer";

    [Header("Score")]
    public int score = 100;

    [Header("Photo Settings")]
    public bool canBePhotographedAgain = false;

    private bool hasBeenPhotographed = false;

    public string GetTargetID()
    {
        return targetID;
    }

    public string GetTargetName()
    {
        return targetName;
    }

    public int GetScore()
    {
        return score;
    }

    public bool CanTakePhoto()
    {
        if (canBePhotographedAgain)
        {
            return true;
        }

        return !hasBeenPhotographed;
    }

    public void Photograph()
    {
        hasBeenPhotographed = true;

        // ¸æËßÍ¼¼øÏµÍ³
        if (CollectionManager.Instance != null)
        {
            CollectionManager.Instance.RegisterPhoto(targetID);
        }
    }
}

