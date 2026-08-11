using UnityEngine;

public class PhotoTarget : MonoBehaviour
{
    [Header("Target Information")]
    public string targetName = "Unknown";

    [Header("Score")]
    public int score = 100;

    [Header("Photo Settings")]
    public bool canBePhotographedAgain = false;

    private bool hasBeenPhotographed = false;

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
    }
}

