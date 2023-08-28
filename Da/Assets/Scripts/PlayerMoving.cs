using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoving : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;
    private int direction = 1;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(moveSpeed * direction, rb.velocity.y);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HitPlayer"))
        {
            Die();
        }

        if(collision.gameObject.CompareTag("Wall"))
        {
            Flip();
        }
    }
    private void Flip()
    {
        direction *= -1;
        rb.velocity = new Vector2(moveSpeed * direction, rb.velocity.y);
        transform.Rotate(Vector3.up, 180f);
    }
    private void Die()
    {
        SceneManager.LoadScene("Main");

    }
}
