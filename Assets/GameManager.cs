using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameEnded = false;

    public GameObject gameOverPanel;
    public GameObject victoryPanel;

    public EnemySpawner enemySpawner;

    void Awake()
    {
        instance = this;
    }

    public void SlowTime(float duration)
    {
        CancelInvoke(nameof(NormalTime));
        Time.timeScale = 0.5f;
        Invoke(nameof(NormalTime), duration);
    }

    void NormalTime()
    {
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        if (isGameEnded) return;

        isGameEnded = true;
        Time.timeScale = 0f;

        if (enemySpawner != null)
            enemySpawner.StopSpawner();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Debug.Log("DERROTA");
    }

    public void Victory()
    {
        if (isGameEnded) return;

        isGameEnded = true;
        Time.timeScale = 0f;

        if (enemySpawner != null)
            enemySpawner.StopSpawner();

        if (victoryPanel != null)
            victoryPanel.SetActive(true);

        Debug.Log("VITÓRIA");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}