// // using UnityEngine;
// // using UnityEngine.SceneManagement;

// // public class GameManager : MonoBehaviour
// // {
// //     public static GameManager instance;

// //     public bool isGameEnded = false;

// //     public GameObject gameOverPanel;
// //     public GameObject victoryPanel;

// //     public EnemySpawner enemySpawner;

// //     void Awake()
// //     {
// //         instance = this;
// //     }

// //     void Start()
// //     {
// //         Time.timeScale = 1f;

// //         if (gameOverPanel != null) gameOverPanel.SetActive(false);
// //         if (victoryPanel != null) victoryPanel.SetActive(false);
// //     }

// //     public void SlowTime(float duration)
// //     {
// //         CancelInvoke(nameof(NormalTime));
// //         Time.timeScale = 0.5f;
// //         Invoke(nameof(NormalTime), duration);
// //     }

// //     void NormalTime()
// //     {
// //         Time.timeScale = 1f;
// //     }

// //     public void GameOver()
// //     {
// //         if (isGameEnded) return;

// //         isGameEnded = true;
// //         Time.timeScale = 0f;

// //         if (enemySpawner != null)
// //             enemySpawner.StopSpawner();

// //         if (gameOverPanel != null)
// //             gameOverPanel.SetActive(true);
// //     }

// //     public void Victory()
// //     {
// //         if (isGameEnded) return;

// //         isGameEnded = true;
// //         Time.timeScale = 0f;

// //         if (enemySpawner != null)
// //             enemySpawner.StopSpawner();

// //         if (victoryPanel != null)
// //             victoryPanel.SetActive(true);
// //     }

// //     public void RestartGame()
// //     {
// //         Time.timeScale = 1f;
// //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
// //     }
// // }
// using UnityEngine;
// using System.Collections;

// public class GameManager : MonoBehaviour
// {
//     public static GameManager instance;

//     public bool isGameEnded = false;

//     [Header("Power Up de Lentidão")]
//     public bool slowModeActive = false;
//     public float enemySpeedMultiplier = 0.5f;
//     public float enemyBulletSpeedMultiplier = 0.5f;
//     public float slowModeDuration = 5f;

//     private Coroutine slowModeCoroutine;

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

//     public void GameOver()
//     {
//         isGameEnded = true;
//         Debug.Log("Game Over");
//     }

//     public void CheckScoreForSlowMode(int currentScore)
//     {
//         if (currentScore > 0 && currentScore % 100 == 0)
//         {
//             SlowTime();
//         }
//     }

//     public void SlowTime()
//     {
//         if (slowModeCoroutine != null)
//         {
//             StopCoroutine(slowModeCoroutine);
//         }

//         slowModeCoroutine = StartCoroutine(SlowModeRoutine());
//     }

//     IEnumerator SlowModeRoutine()
//     {
//         slowModeActive = true;
//         Debug.Log("Power Up ativado!");

//         yield return new WaitForSeconds(slowModeDuration);

//         slowModeActive = false;
//         slowModeCoroutine = null;
//         Debug.Log("Power Up terminou.");
//     }
// }

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameEnded = false;

    [Header("Cenas")]
    public string gameOverSceneName = "Derrota";
    public string victorySceneName = "Vitoria";

    [Header("Power Up de Lentidão")]
    public bool slowModeActive = false;
    public float enemySpeedMultiplier = 0.5f;
    public float enemyBulletSpeedMultiplier = 0.5f;
    public float slowModeDuration = 5f;

    private Coroutine slowModeCoroutine;

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

    public void GameOver()
    {
        if (isGameEnded) return;

        isGameEnded = true;
        SceneManager.LoadScene(gameOverSceneName);
    }

    public void Victory()
    {
        if (isGameEnded) return;

        isGameEnded = true;
        SceneManager.LoadScene(victorySceneName);
    }

    public void SlowTime()
    {
        SlowTime(slowModeDuration);
    }

    public void SlowTime(float duration)
    {
        if (slowModeCoroutine != null)
        {
            StopCoroutine(slowModeCoroutine);
        }

        slowModeCoroutine = StartCoroutine(SlowModeRoutine(duration));
    }

    IEnumerator SlowModeRoutine(float duration)
    {
        slowModeActive = true;

        yield return new WaitForSeconds(duration);

        slowModeActive = false;
        slowModeCoroutine = null;
    }
}