using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode shootKey = KeyCode.Space;

    public float speed = 3f;
    public float boundY = 2f;
    public float boundX = 4.3f;

    [Header("Tiro do player")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Update()
    {
        if (GameManager.instance != null && GameManager.instance.isGameEnded) return;

        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(moveUp)) moveDirection += Vector3.up;
        if (Input.GetKey(moveDown)) moveDirection += Vector3.down;
        if (Input.GetKey(moveLeft)) moveDirection += Vector3.left;
        if (Input.GetKey(moveRight)) moveDirection += Vector3.right;

        transform.position += moveDirection.normalized * speed * Time.deltaTime;

        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -boundY, boundY);
        pos.x = Mathf.Clamp(pos.x, -boundX, boundX);
        transform.position = pos;

        if (Input.GetKeyDown(shootKey))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Bullet Prefab ou FirePoint do player não configurado.");
        }
    }
}