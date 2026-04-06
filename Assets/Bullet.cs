using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 12f;
    public float maxX = 15f;

    void Update()
    {
        if (GameManager.instance != null && GameManager.instance.isGameEnded) return;

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (transform.position.x > maxX)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddPoint(10);
            }
        }
    }
}
