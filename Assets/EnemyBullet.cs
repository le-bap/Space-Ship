// // using UnityEngine;

// // public class EnemyBullet : MonoBehaviour
// // {
// //     public float speed = 8f;
// //     public float lifeTime = 4f;

// //     void Start()
// //     {
// //         Destroy(gameObject, lifeTime);
// //     }

// //     void Update()
// //     {
// //         transform.Translate(Vector3.left * speed * Time.deltaTime);
// //     }

// //     void OnTriggerEnter2D(Collider2D other)
// //     {
// //         if (other.CompareTag("Player"))
// //         {
// //             if (GameManager.instance != null)
// //             {
// //                 GameManager.instance.GameOver();
// //             }

// //             Destroy(gameObject);
// //         }
// //     }
// // }

// using UnityEngine;

// public class EnemyBullet : MonoBehaviour
// {
//     public float speed = 10f;
//     public float lifeTime = 5f;

//     void Start()
//     {
//         Destroy(gameObject, lifeTime);
//     }

//     void Update()
//     {
//         float currentSpeed = speed;

//         if (GameManager.instance != null && GameManager.instance.slowModeActive)
//         {
//             currentSpeed *= GameManager.instance.enemyBulletSpeedMultiplier;
//         }

//         transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
//     }

//     void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             if (GameManager.instance != null)
//             {
//                 GameManager.instance.GameOver();
//             }

//             Destroy(gameObject);
//         }
//     }
// }

using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        float currentSpeed = speed;

        if (GameManager.instance != null && GameManager.instance.slowModeActive)
        {
            currentSpeed *= GameManager.instance.enemyBulletSpeedMultiplier;
        }

        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.GameOver();
            }

            Destroy(gameObject);
        }
    }
}