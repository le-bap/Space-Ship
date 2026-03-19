using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode shootKey = KeyCode.Space;

    public float speed = 3.0f;

    private float boundY = 2.0f;
    private float boundX = 4.3f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameManager.instance.isGameEnded) return;

        Vector2 vel = Vector2.zero;

        if (Input.GetKey(moveUp)) vel.y = speed;
        if (Input.GetKey(moveDown)) vel.y = -speed;
        if (Input.GetKey(moveLeft)) vel.x = -speed;
        if (Input.GetKey(moveRight)) vel.x = speed;

        rb2d.linearVelocity = vel;

        if (Input.GetKeyDown(shootKey))
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }

        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -boundY, boundY);
        pos.x = Mathf.Clamp(pos.x, -boundX, boundX);
        transform.position = pos;
    }
}