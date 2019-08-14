using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float xinput;
    public float moveSpeed;
    public float jumpForce;

    public bool canJump = false;

    Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = this.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        xinput = Input.GetAxis("Horizontal");

        playerRB.velocity = new Vector2(xinput * moveSpeed, playerRB.velocity.y);

        if(Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            playerRB.AddForce(new Vector2(0,jumpForce), ForceMode.Impulse);
            canJump = false;
        }
        
    }

/*
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "ground")
        {
            canJump = true;
        }
    }
    */
}
