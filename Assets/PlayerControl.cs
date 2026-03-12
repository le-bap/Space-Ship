using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    public KeyCode moveUp = KeyCode.W;      
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;    
    public KeyCode moveRight = KeyCode.D;
    public float speed = 3.0f;             
    private float boundY = 2.0f;
    private float boundX = 4.3f;            
    private Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.linearVelocity;                // Acessa a velocidade da raquete
        if (Input.GetKey(moveUp)) {             // Velocidade da Raquete para ir para cima
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown)) {      // Velocidade da Raquete para ir para cima
            vel.y = -speed;                    
        }
        else if (Input.GetKey(moveLeft)) {      // Velocidade da Raquete para ir para cima
            vel.x = -speed;                    
        }
        else if (Input.GetKey(moveRight)) {      // Velocidade da Raquete para ir para cima
            vel.x = speed;                    
        }
        else {
            vel.y = 0;                          // Velociade para manter a raquete parada
            vel.x = 0;  
        }
        rb2d.linearVelocity = vel;                    // Atualizada a velocidade da raquete

        var pos = transform.position;           // Acessa a Posição da raquete
        if (pos.y > boundY) {                  
            pos.y = boundY;                     // Corrige a posicao da raquete caso ele ultrapasse o limite superior
        }
        else if (pos.y < -boundY) {
            pos.y = -boundY;                    // Corrige a posicao da raquete caso ele ultrapasse o limite inferior
        }
        if (pos.x > boundX) {                  
            pos.x = boundX;                     // Corrige a posicao da raquete caso ele ultrapasse o limite superior
        }
        else if (pos.x < -boundX) {
            pos.x = -boundX;                    // Corrige a posicao da raquete caso ele ultrapasse o limite inferior
        }
        transform.position = pos;               // Atualiza a posição da raquete

        }
}
