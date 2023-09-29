using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public GameObject Plus;
    public GameObject Minus;
    private GameController gameController;
    private int rand;
    // 0 is plus
    // 1 is minus
    private void Start()
    {
        Debug.Log("da");
        rand = Random.Range(1, 2);

        if (rand == 2)
        {
            Plus.SetActive(true);
        }
        else
        {
            Minus.SetActive(true);
        }
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (rand == 2)
            {
                gameController.ScorePlus();
                gameController.ScorePlus();
            }
            else
            {
                gameController.ScoreMinus();
                gameController.ScoreMinus();
            }
            
            gameObject.SetActive(false);
        }
    }
}
