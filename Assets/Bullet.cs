
// using UnityEngine;

// public class Bullet : MonoBehaviour
// {
//     public float speed = 12f;
//     public float lifeTime = 2f;

//     void Start()
//     {
//         Destroy(gameObject, lifeTime);
//     }

//     void Update()
//     {
//         transform.Translate(Vector3.right * speed * Time.deltaTime);
//     }

//     void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Enemy"))
//         {
//             Destroy(other.gameObject);
//             Destroy(gameObject);

//             if (ScoreManager.instance != null)
//             {
//                 ScoreManager.instance.AddScore(10);
//             }
//         }
//     }
// }

using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(10);
            }
        }
    }
}