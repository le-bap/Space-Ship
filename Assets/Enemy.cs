using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float destroyX = -12f;

    [Header("Tiro do inimigo")]
    public GameObject enemyBulletPrefab;
    public Transform firePoint;
    public float shootInterval = 2f;

    private float shootTimer;

    void Update()
    {
        if (GameManager.instance != null && GameManager.instance.isGameEnded) return;

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        if (enemyBulletPrefab != null && firePoint != null)
        {
            Instantiate(enemyBulletPrefab, firePoint.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.instance != null)
                GameManager.instance.GameOver();
        }
    }
}