using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 2f;
    public float gravity = 2f;
    public float speedRotate = 3;
    public GameObject featherUp;
    public GameObject featherDown;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0) && !PlayerMoving.lose)
        {
            Jump();
        }
        else if (PlayerMoving.lose)
        {
            featherUp.SetActive(false);
            featherDown.SetActive(false);
        }
        
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        featherDown.SetActive(true);
        featherUp.SetActive(false);
        Invoke("Down", 0.5f);
    }
    private void Down()
    {
        
        featherDown.SetActive(false);
        featherUp.SetActive(true);
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
