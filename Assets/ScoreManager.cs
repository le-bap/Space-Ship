using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public Text scoreText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void AddPoint(int value)
    {
        score += value;
        UpdateScoreText();

        if (score >= 100)
        {
            GameManager.instance.Victory();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}