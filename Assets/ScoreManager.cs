// // using UnityEngine;
// // using TMPro;

// // public class ScoreManager : MonoBehaviour
// // {
// //     public static ScoreManager instance;

// //     public int score = 0;
// //     public TextMeshProUGUI scoreText;

// //     void Awake()
// //     {
// //         if (instance == null)
// //         {
// //             instance = this;
// //         }
// //         else
// //         {
// //             Destroy(gameObject);
// //         }
// //     }

// //     void Start()
// //     {
// //         UpdateScoreText();
// //     }

// //     public void AddScore(int amount)
// //     {
// //         score += amount;
// //         UpdateScoreText();
// //     }

// //     void UpdateScoreText()
// //     {
// //         if (scoreText != null)
// //         {
// //             scoreText.text = "Score: " + score;
// //         }
// //     }
// // }

// using UnityEngine;
// using TMPro;

// public class ScoreManager : MonoBehaviour
// {
//     public static ScoreManager instance;

//     public int score = 0;
//     public TextMeshProUGUI scoreText;

//     void Awake()
//     {
//         if (instance == null)
//         {
//             instance = this;
//         }
//         else
//         {
//             Destroy(gameObject);
//         }
//     }

//     void Start()
//     {
//         UpdateScoreText();
//     }

//     public void AddScore(int amount)
//     {
//         int oldScore = score;
//         score += amount;
//         UpdateScoreText();

//         if (GameManager.instance != null)
//         {
//             int oldHundreds = oldScore / 100;
//             int newHundreds = score / 100;

//             if (newHundreds > oldHundreds)
//             {
//                 GameManager.instance.SlowTime();
//             }
//         }
//     }

//     void UpdateScoreText()
//     {
//         if (scoreText != null)
//         {
//             scoreText.text = "Score: " + score;
//         }
//     }
// }

using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        int oldScore = score;
        score += amount;
        UpdateScoreText();

        if (GameManager.instance != null)
        {
            int oldHundreds = oldScore / 100;
            int newHundreds = score / 100;

            if (newHundreds > oldHundreds)
            {
                GameManager.instance.SlowTime();
            }

            if (score >= 200)
            {
                GameManager.instance.Victory();
            }
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}