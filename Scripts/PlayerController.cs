using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    public float force = 10;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal"); //capturamos teclado
        playerRB.velocity = (transform.right * movement * force); //aplicamos fuerza para mover el player
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
