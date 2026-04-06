// using UnityEngine;
// using TMPro;

// public class ScoreManager : MonoBehaviour
// {
//     public static ScoreManager instance;

//     public int score = 0;
//     public TMP_Text scoreText;

//     void Awake()
//     {
//         instance = this;
//     }

//     void Start()
//     {
//         UpdateScoreText();
//     }

//     public void AddPoint(int value)
//     {
//         score += value;
//         UpdateScoreText();

//         if (score >= 100)
//         {
//             GameManager.instance.Victory();
//         }
//     }

//     void UpdateScoreText()
//     {
//         if (scoreText != null)
//             scoreText.text = "Score: " + score;
//     }
// }

// using UnityEngine;
// using TMPro;

// public class ScoreManager : MonoBehaviour
// {
//     public static ScoreManager instance;

//     public int score = 0;
//     public TMP_Text scoreText;

//     void Awake()
//     {
//         instance = this;
//     }

//     void Start()
//     {
//         UpdateScoreText();
//     }

//     public void AddPoint(int value)
//     {
//         score += value;
//         UpdateScoreText();
//     }

//     void UpdateScoreText()
//     {
//         if (scoreText != null)
//             scoreText.text = "Score: " + score;
//     }
// }

using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TMP_Text scoreText;
    public int scoreToWin = 100;

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

        if (score >= scoreToWin)
        {
            if (GameManager.instance != null)
                GameManager.instance.Victory();
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}