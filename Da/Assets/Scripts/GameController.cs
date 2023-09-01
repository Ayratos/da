using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] trianglesLeft;
    public GameObject[] trianglesRight;
    private bool left; //летит к левой стенке
    private int NumOfSpikes;
    private int IndexLeft;
    private int IndexRight;

    public float scoreCounter;
    public float highScoreCounter;
    public TextMesh score;
    public Text highScore;
    //private TextLanguage TextLang;

    public void Triangle()
    {
        if (!left)
        {
            
            TriangleLeft();
            //летит налево

        }
        else if (left)
        {

            TriangleRight();
            //летит направо
        }
    }
    void TriangleLeft()
    {
        IndexLeft = Random.Range(0, trianglesLeft.Length);
        trianglesLeft[IndexLeft].SetActive(true);
        int IndexLeft2;
        do
        {
            IndexLeft2 = Random.Range(0, trianglesLeft.Length);
            trianglesLeft[IndexLeft2].SetActive(true);
        } while (IndexLeft2 == IndexLeft);
        //int IndexLeft3;
        //do
        //{
        //    IndexLeft3 = Random.Range(0, trianglesLeft.Length);
        //    trianglesLeft[IndexLeft3].SetActive(true);
        //} while (IndexLeft3 != IndexLeft);

        left = true;
        
        int i = 0;
        while (i < 16)
        {
            trianglesRight[i++].SetActive(false);
        }
    }
    void TriangleRight()
    {
        
        IndexRight = Random.Range(0, trianglesRight.Length);
        trianglesRight[IndexRight].SetActive(true);
        int IndexRight2;
        do 
        {
            IndexRight2 = Random.Range(0, trianglesRight.Length);
            trianglesRight[IndexRight2].SetActive(true);
        } while (IndexRight2 == IndexRight);
        //int IndexRight3;
        //do
        //{
        //    IndexRight3 = Random.Range(0, trianglesRight.Length);
        //    trianglesRight[IndexRight3].SetActive(true);
        //} while (IndexRight3 != IndexLeft);
        left = false;


        int i = 0;
        while (i < 16)
        {
            trianglesLeft[i++].SetActive(false);
        }
    }
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
            Triangle();
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
        if (scoreCounter <= 9)
        {
            score.text = 0 + scoreCounter.ToString("f0");
        }
        else if (scoreCounter >= 10 && scoreCounter < 100)
        {
            score.text = scoreCounter.ToString("f0");
        }
    }
    void HscoreText()
    {
        if (highScoreCounter  <= 10)
        {
            highScore.text = 0 + highScoreCounter.ToString("f0");
        }
        else if (highScoreCounter >= 8 && scoreCounter < 100)
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
