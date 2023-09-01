using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 2f;
    public float gravity = 2f;
    public float speedRotate = 3;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            Jump();
        }
        
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    private void RotDown()
    {
        transform.Rotate(Vector3.forward * speedRotate);
    }
    //private void FixedUpdate()
    //{
    //    transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * speedRotate);
    //}
}
