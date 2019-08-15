using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementFinished : MonoBehaviour
{
    // In Unity 'public' also exposes variables to the inspector, which is useful for debugging and learning
    public float xinput;
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
        // Unity function that get's input from WASD or the arrow keys. Returns -1 or 1
        xinput = Input.GetAxis("Horizontal");

        // Keep the y-velocity so we can jump
        playerRB.velocity = new Vector2(xinput * moveSpeed, playerRB.velocity.y);

        if(Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            playerRB.AddForce(new Vector2(0,jumpForce), ForceMode.Impulse);
            canJump = false;
        }
        
    }

    // Unity function that gives us access to anything colliding with this object
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "ground")
        {
            canJump = true;
        }
    }

}
