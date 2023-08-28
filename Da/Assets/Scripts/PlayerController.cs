using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float gravity = 4f;
    private bool isDead = false;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Jump();
            }
        }
        
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void Die()
    {
        isDead = true;
    }
}
