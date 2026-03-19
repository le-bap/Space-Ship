using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float slowDuration = 5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.SlowTime(slowDuration);
            Destroy(gameObject);
        }
    }
}