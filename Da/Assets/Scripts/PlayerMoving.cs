using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoving : MonoBehaviour
{
    public float moveSpeed = 25;
    public float rotationSpeed = 180;
    private int direction = 1;
    private Rigidbody2D rb;
    public static bool lose; //��������
    public GameObject ReplayMenu; //���� ��������
    public GameObject Dead;
    public static bool touchedWall; //���������� ������������
    public GameController gameController;
    void Start()
    {
        touchedWall = false;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(moveSpeed * direction, rb.velocity.y);
        lose = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HitPlayer") && !lose)
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Square") && !lose)
        {
            
            gameController.Triangle();
            Flip();
            //gameController.ScorePlus();
            //gameController.ScorePlus();
        }

        if (collision.gameObject.CompareTag("Wall") && !lose)
        {
            Flip();
        }
        else if (!collision.gameObject.CompareTag("Wall") && !lose)
        {
            touchedWall = false;
        }
    }
    private void Flip()
    {
        direction *= -1;
        rb.velocity = new Vector2(moveSpeed * direction, rb.velocity.y);
        transform.Rotate(Vector3.up, 180f);
        //if (gameController != null)
        //    gameController.ScorePlus();
        touchedWall = true;
    }
    private void Die()
    {
        lose = true;
        ReplayMenu.SetActive(true);
        Dead.SetActive(true);

    }
    public void Replay()
    {
        SceneManager.LoadScene("Main");
    }
}
