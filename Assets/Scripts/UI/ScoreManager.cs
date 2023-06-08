using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    int score;
    Text scoreText;
    int highScore;

    public Text panelScore;
    public Text panelHighScore;
    public GameObject New;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText= GetComponent<Text>();
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();
        highScore = PlayerPrefs.GetInt("highscore");
        panelHighScore.text = highScore.ToString();
    }


    public void Scored()
    {
        score++;
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();
        if (score > highScore)
        {
            highScore = score;
            panelHighScore.text = score.ToString();
            PlayerPrefs.SetInt("highscore", highScore);
            New.SetActive(true);
        }


    }

    public int GetScore()
    {
        return score;
    }


   
}
