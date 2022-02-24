using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    SpriteRenderer playerRenderer;
    public float force = 5;
    //con estra booleana controlamos donde mira el avatar (la usamos de condicional en el FixedUpdate)
    bool faceRigth = true;
    Animator animator;
    public float jumpForce;
    public bool IsGrounded;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Physics2D.queriesStartInColliders = false;
    }

    private void FixedUpdate()
    {

        animator.SetFloat("VerticalVelocity", playerRB.velocity.y);
        Debug.Log("Velocidad en y " + playerRB.velocity.y);

        float movement = Input.GetAxis("Horizontal"); //capturamos teclado
        playerRB.velocity = (transform.right * movement * force); //aplicamos fuerza para mover el player
        if(movement > 0 && !faceRigth) //si nos movemos a la derecha, x es menor que 0, y faceRigt es false
        {
            Turn();
        }
        else
        {
            if(movement < 0 && faceRigth)
            {
                Turn();
            }           
        }

        animator.SetFloat("MoveSpeed", Mathf.Abs(movement)); //creamos un componente animator para acceder a la animacion, accedemos a SetFloat y le asignamos un valor
        // de acuerdo con la variable moveSpeed 
        //le pasamos el valor move pasado a Absoluto, 

        if(Input.GetAxis("Jump") > 0 && IsGrounded == true)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
            playerRB.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            IsGrounded = false;
            animator.SetBool("IsGrounded", false);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        if (hit.collider != null && IsGrounded == false && playerRB.velocity.y < 0 && hit.collider.gameObject.tag == "floor")
        {
            if (hit.distance < 0.5)
            {
                Debug.Log("Detecto un objeto " + hit.collider.gameObject.name + " a una distancia de " + hit.distance);
                IsGrounded = true;
                animator.SetBool("IsGrounded", true);
            }
        }


    }

    void Turn() //accedemos a transfor.localScale y le asignamos un nuevo vector2 cambiando la posicion de la x al valor negativo para que gire, la y no la tocamos
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        faceRigth = !faceRigth; // faceRigth tomara el valor contratio del valor que tuviera
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
