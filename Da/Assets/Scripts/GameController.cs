using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class GameController : MonoBehaviour
{
    public GameObject[] trianglesLeft;
    public GameObject[] trianglesRight;
    public GameObject[] squareR;
    public GameObject[] squareL;
    int squarelcounterR;
    int squarelcounterL;
    private bool left; //летит к левой стенке
    private int NumOfSpikes;
    private int IndexLeft;
    private int IndexRight;

    public float scoreCounter;
    public float highScoreCounter;
    public TextMesh score;
    public Text highScore;
    public Text scoreT;
    //private TextLanguage TextLang;

    private SpriteRenderer Current;

    private void Start()
    {
        if (PlayerPrefs.HasKey("SaveScore"))
            highScoreCounter = PlayerPrefs.GetFloat("SaveScore");
        //TextLang = score.GetComponent<TextLanguage>();
        Current = GetComponent<SpriteRenderer>();
        
    }
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
        squarelcounterL = Random.Range(1, 15);
        squareL[squarelcounterL].SetActive(true);
        squareR[squarelcounterR].SetActive(false);
        int triangelcounter = Random.Range(1, 7);
        do
        {
            int IndexLeft = Random.Range(0,trianglesLeft.Length);
            trianglesLeft[IndexLeft].SetActive(true);
            --triangelcounter;
        } while (triangelcounter != 0);

        left = true;
        
        int i = 0;
        while (i < trianglesRight.Length)
        {
            trianglesRight[i++].SetActive(false);
        }
    }
    void TriangleRight()
    {
        
        IndexRight = Random.Range(0, trianglesRight.Length);
        trianglesRight[IndexRight].SetActive(true);
        squarelcounterR = Random.Range(1, 15);
        squareR[squarelcounterR].SetActive(true);
        squareL[squarelcounterL].SetActive(false);
        int triangelcounter = Random.Range(1, 7);
        do //Добавляет нужные шипы
        {
            int IndexRight = Random.Range(0,trianglesRight.Length);
            trianglesRight[IndexRight].SetActive(true);
            --triangelcounter;
        } while (triangelcounter != 0);
        
        left = false;



        int i = 0;
        while (i < trianglesLeft.Length) //Скрывание ненужных шипов
        {
            trianglesLeft[i++].SetActive(false);
        }
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
        if (scoreCounter == 5)
        {
            ColorChange1();
        }
        else if (scoreCounter == 10)
        {
            ColorChange2();
        }
        else if (scoreCounter == 15)
        {
            ColorChange3();
        }
        else if (scoreCounter == 20)
        {
            ColorChange4();
        }
        else if (scoreCounter == 25)
        {
            ColorChange5();
        }
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
        if (scoreCounter <= 9)
        {
            scoreT.text = 0 + scoreCounter.ToString("f0");
        }
        else if (scoreCounter >= 10 && scoreCounter < 100)
        {
            scoreT.text = scoreCounter.ToString("f0");
        }
    }
    void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("SaveScore");
        highScoreCounter = 0;
    }
    IEnumerator FadeOut()
    {
        for (float f = 0.05f; f < 1f; f += 0.02f)
        {
            Color c = Current.material.color;
            c.b = 1;
            Current.material.color = c;
            yield return new WaitForSeconds(0.05f);

        }
    }
    void ColorChange1()
    {
        Current.material.color = Color.Lerp(Current.material.color, Color.green, 2 * Time.deltaTime);
        
    }
    void ColorChange2()
    {
        Current.material.color = Color.Lerp(Current.material.color, Color.blue, 2 * Time.deltaTime);
    }
    void ColorChange3()
    {
        Current.material.color = Color.Lerp(Current.material.color, Color.black, 2 * Time.deltaTime);
    }
    void ColorChange4()
    {
        Current.material.color = Color.Lerp(Current.material.color, Color.yellow, 2 * Time.deltaTime);
    }
    void ColorChange5()
    {
        Current.material.color = Color.Lerp(Current.material.color, Color.red, 2 * Time.deltaTime);
    }
}
