using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
     // Set mass to 100. Set gravity scale to 3. Freeze rotation along Z-axis.
    Rigidbody rb;

    public float speed = 5.0f;
    public float jumpSpeed = 12.0f;

    public bool canJump = false;
    public bool canMove = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Explains 'FixedUpdate' -> http://unity3d.com/learn/tutorials/topics/scripting/update-and-fixedupdate
    void FixedUpdate()
    {
        // Explains 'GetAxis' -> https://unity3d.com/learn/tutorials/topics/scripting/getaxis
        float xinput = Input.GetAxis("Horizontal");

        if (canMove)
            rb.velocity = new Vector2(xinput * speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            canJump = false;
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ground")
            canJump = true;
    }
// Start is called before the first frame update
    void Start()
    {
        
    }

}
