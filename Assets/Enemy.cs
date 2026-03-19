using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        if (GameManager.instance.isGameEnded) return;

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }
    }
}