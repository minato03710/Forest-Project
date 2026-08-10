using UnityEngine;

public class PhotoTarget : MonoBehaviour
{
    [Header("Target Information")]
    public string targetName = "Unknown";

    [Header("Score")]
    public int score = 100;

    public string GetTargetName()
    {
        return targetName;
    }

    public int GetScore()
    {
        return score;
    }
}