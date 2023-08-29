using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float scoreCounter;
    public float highScoreCounter;
    public TextMesh score;
    public Text highScore;
    //private TextLanguage TextLang;
    private void Start()
    {
        if (PlayerPrefs.HasKey("SaveScore"))
            highScoreCounter = PlayerPrefs.GetFloat("SaveScore");
        //TextLang = score.GetComponent<TextLanguage>();
    }
    void Update()
    {
        if(PlayerMoving.touchedWall)
        {
            ScorePlus();
        }
        if (!PlayerMoving.lose)
        {
            ScoreText();
        }
        if (PlayerMoving.lose)
        {
            HscoreText();
            
        }
        if (scoreCounter > highScoreCounter)
        {
            highScoreCounter = scoreCounter;
            PlayerPrefs.SetFloat("SaveScore", highScoreCounter);
        }
        //else if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    Invoke("ResetHighScore", 1);
        //}
    }
    public void ScorePlus()
    {
        scoreCounter++;
        PlayerMoving.touchedWall = false;
    }
    void ScoreText()
    {
        if (scoreCounter < 9)
        {
            score.text = 0 + scoreCounter.ToString("f0");
        }
        else if (scoreCounter > 10 && scoreCounter < 100)
        {
            score.text = scoreCounter.ToString("f0");
        }
    }
    void HscoreText()
    {
        if (highScoreCounter < 10)
        {
            highScore.text = 0 + highScoreCounter.ToString("f0");
        }
        else if (highScoreCounter > 8 && scoreCounter < 100)
        {
            highScore.text = highScoreCounter.ToString("f0");
        }
        PlayerPrefs.SetFloat("SaveScore", highScoreCounter);
    }
    void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("SaveScore");
        highScoreCounter = 0;
    }
}
