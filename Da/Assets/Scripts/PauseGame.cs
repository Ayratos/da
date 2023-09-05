using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isgamepaused = true;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            isgamepaused = false;
        }
        PausingGame();
    }

    private void PausingGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isgamepaused)
            {
                Time.timeScale = 1;
                isgamepaused = false;
            }
            else {
                Time.timeScale = 0;
                isgamepaused = true;
            }
        }
    }
}
