using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 8f;
    public float destroyX = -15f;

    void Update()
    {
        if (GameManager.instance != null && GameManager.instance.isGameEnded) return;

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.instance != null)
                GameManager.instance.GameOver();

            Destroy(gameObject);
        }
    }
}