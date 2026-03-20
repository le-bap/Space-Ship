using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        if (GameManager.instance.isGameEnded) return;

        transform.Translate(Vector2.left * speed * Time.deltaTime);
        Debug.Log(transform.position.x);
        if (transform.position.x < -5f)
        {
            Respawn();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }
    }
    
    void Respawn()
    {
        Debug.Log("RESPAWNANDO");
        float randomY = Random.Range(-4f, 4f);
        transform.position = new Vector2(10f, randomY);
    }
}