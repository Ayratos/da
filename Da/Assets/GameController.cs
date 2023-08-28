using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float scoreCounter;
    public float highScoreCounter;
    public Text score;
    public Text highScore;
    private TextLanguage TextLang;
    private void Start()
    {
        if (PlayerPrefs.HasKey("SaveScore"))
            highScoreCounter = PlayerPrefs.GetFloat("SaveScore");
        TextLang = score.GetComponent<TextLanguage>();
    }
    void Update()
    {
        if (!Player.lose && !LevelsButton.GamePaused)
        {
            scoreCounter += Time.deltaTime;
            ScoreText();
        }
        if (!Player.lose && !LevelsButton.GamePaused)
        {
            scoreCounter += Laser.BombDestroy;
        }
        if (Player.lose)
        {
            HscoreText();
            PlayerPrefs.SetFloat("SaveScore", highScoreCounter);
        }
        else if (scoreCounter > highScoreCounter)
        {
            highScoreCounter = scoreCounter;

            PlayerPrefs.SetFloat("SaveScore", highScoreCounter);
        }
        //else if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    Invoke("ResetHighScore", 1);
        //}
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
            highScore.text = 0 + scoreCounter.ToString("f0");
        }
        else if (highScoreCounter > 8 && scoreCounter < 100)
        {
            highScore.text = scoreCounter.ToString("f0");
        }
    }
    void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("SaveScore");
        highScoreCounter = 0;
    }
}
