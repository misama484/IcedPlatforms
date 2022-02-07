using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    SpriteRenderer playerRenderer;
    public float force = 10;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal"); //capturamos teclado
        playerRB.velocity = (transform.right * movement * force); //aplicamos fuerza para mover el player
        if(movement < 0)
        {
            playerRenderer.flipX = true;
        }
        else
        {
            playerRenderer.flipX = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
