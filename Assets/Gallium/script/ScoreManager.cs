using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("Score")]
    public int currentScore = 0;

    [Header("UI")]
    public TMP_Text scoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;

        UpdateScoreUI();

        Debug.Log("Current Score: " + currentScore);
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "SCORE: " + currentScore;
        }
    }

    public int GetScore()
    {
        return currentScore;
    }
}



