using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime = 1.2f;

    [Header("Área de Spawn")]
    public float minY = -1.5f;
    public float maxY = 1.5f;
    public float spawnX = 4.8f;

    [Header("Wave")]
    public int enemiesPerSpawn = 2;
    public float spacingY = 0.9f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemyWave), 1f, spawnTime);
    }

    void SpawnEnemyWave()
    {
        if (GameManager.instance != null && GameManager.instance.isGameEnded) return;

        if (enemyPrefab == null)
        {
            Debug.LogWarning("Enemy Prefab não foi atribuído no EnemySpawner.");
            return;
        }

        float totalHeight = (enemiesPerSpawn - 1) * spacingY;
        float startY = Random.Range(minY, maxY - totalHeight);

        for (int i = 0; i < enemiesPerSpawn; i++)
        {
            float y = startY + (i * spacingY);
            Instantiate(enemyPrefab, new Vector2(spawnX, y), Quaternion.identity);
        }
    }

    public void StopSpawner()
    {
        CancelInvoke(nameof(SpawnEnemyWave));
    }
}