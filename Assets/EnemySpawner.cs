using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime = 2f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnTime);
    }

    void SpawnEnemy()
    {
        if (GameManager.instance.isGameEnded) return;

        float y = Random.Range(-2f, 2f);
        Instantiate(enemyPrefab, new Vector2(10f, y), Quaternion.identity);
    }

    public void StopSpawner()
    {
        CancelInvoke(nameof(SpawnEnemy));
    }
}