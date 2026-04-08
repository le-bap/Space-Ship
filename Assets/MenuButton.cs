using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public string gameSceneName = "SampleScene";

    public void RestartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}