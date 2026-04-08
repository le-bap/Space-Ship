// // // using UnityEngine;

// // // public class Enemy : MonoBehaviour
// // // {
// // //     public float speed = 3f;
// // //     public float destroyX = -12f;

// // //     [Header("Tiro do inimigo")]
// // //     public GameObject enemyBulletPrefab;
// // //     public Transform firePoint;
// // //     public float shootInterval = 2f;

// // //     private float shootTimer;

// // //     void Update()
// // //     {
// // //         if (GameManager.instance != null && GameManager.instance.isGameEnded) return;

// // //         transform.Translate(Vector2.left * speed * Time.deltaTime);

// // //         shootTimer += Time.deltaTime;
// // //         if (shootTimer >= shootInterval)
// // //         {
// // //             Shoot();
// // //             shootTimer = 0f;
// // //         }

// // //         if (transform.position.x < destroyX)
// // //         {
// // //             Destroy(gameObject);
// // //         }
// // //     }

// // //     void Shoot()
// // //     {
// // //         if (enemyBulletPrefab != null && firePoint != null)
// // //         {
// // //             Instantiate(enemyBulletPrefab, firePoint.position, Quaternion.identity);
// // //         }
// // //     }

// // //     void OnTriggerEnter2D(Collider2D other)
// // //     {
// // //         if (other.CompareTag("Player"))
// // //         {
// // //             if (GameManager.instance != null)
// // //                 GameManager.instance.GameOver();
// // //         }
// // //     }
// // // }
// // using UnityEngine;

// // public class Enemy : MonoBehaviour
// // {
// //     public float speed = 3f;
// //     public float destroyX = -12f;

// //     [Header("Tiro do inimigo")]
// //     public GameObject enemyBulletPrefab;
// //     public Transform firePoint;
// //     public float shootInterval = 2f;

// //     private float shootTimer;

// //     void Start()
// //     {
// //         shootTimer = Random.Range(0f, shootInterval);
// //     }

// //     void Update()
// //     {
// //         transform.Translate(Vector3.left * speed * Time.deltaTime);

// //         shootTimer += Time.deltaTime;
// //         if (shootTimer >= shootInterval)
// //         {
// //             Shoot();
// //             shootTimer = 0f;
// //         }

// //         if (transform.position.x < destroyX)
// //         {
// //             Destroy(gameObject);
// //         }
// //     }

// //     void Shoot()
// //     {
// //         if (enemyBulletPrefab == null || firePoint == null) return;

// //         Instantiate(enemyBulletPrefab, firePoint.position, Quaternion.identity);
// //     }
// // }
// using UnityEngine;

// public class Enemy : MonoBehaviour
// {
//     public float speed = 3f;
//     public float destroyX = -12f;

//     [Header("Tiro do inimigo")]
//     public GameObject enemyBulletPrefab;
//     public float shootInterval = 2f;

//     private float shootTimer;
//     private Transform firePoint;

//     void Awake()
//     {
//         firePoint = transform.Find("EnemyFirePoint");
//     }

//     void Start()
//     {
//         shootTimer = Random.Range(0f, shootInterval);
//     }

//     void Update()
//     {
//         if (GameManager.instance != null && GameManager.instance.isGameEnded)
//             return;

//         float currentSpeed = speed;

//         if (GameManager.instance != null && GameManager.instance.slowModeActive)
//         {
//             currentSpeed *= GameManager.instance.enemySpeedMultiplier;
//         }

//         transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

//         shootTimer += Time.deltaTime;
//         if (shootTimer >= shootInterval)
//         {
//             Shoot();
//             shootTimer = 0f;
//         }

//         if (transform.position.x < destroyX)
//         {
//             Destroy(gameObject);
//         }
//     }

//     void Shoot()
//     {
//         if (enemyBulletPrefab == null)
//             return;

//         Vector3 spawnPosition;

//         if (firePoint != null)
//             spawnPosition = firePoint.position;
//         else
//             spawnPosition = transform.position + Vector3.left * 0.6f;

//         Instantiate(enemyBulletPrefab, spawnPosition, Quaternion.identity);
//     }

//     void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             if (GameManager.instance != null)
//             {
//                 GameManager.instance.GameOver();
//             }
//         }
//     }
// }

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float destroyX = -12f;

    [Header("Tiro do inimigo")]
    public GameObject enemyBulletPrefab;
    public float shootInterval = 2f;

    private float shootTimer;
    private Transform firePoint;

    void Awake()
    {
        firePoint = transform.Find("EnemyFirePoint");
    }

    void Start()
    {
        shootTimer = Random.Range(0f, shootInterval);
    }

    void Update()
    {
        if (GameManager.instance != null && GameManager.instance.isGameEnded)
            return;

        float currentSpeed = speed;

        if (GameManager.instance != null && GameManager.instance.slowModeActive)
        {
            currentSpeed *= GameManager.instance.enemySpeedMultiplier;
        }

        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

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
        if (enemyBulletPrefab == null)
            return;

        Vector3 spawnPosition;

        if (firePoint != null)
            spawnPosition = firePoint.position;
        else
            spawnPosition = transform.position + Vector3.left * 0.6f;

        Instantiate(enemyBulletPrefab, spawnPosition, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.GameOver();
            }
        }
    }
}