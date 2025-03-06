using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public Text Score;
    public Text highScore;
    int i=0;

    private void Start()
    {
        highScore.text = "High Score:"+ PlayerPrefs.GetInt("score");
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("OnTriggerEnter2D");
        i++;
        Score.text = "SCORE:" + i;

        if (i > PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.SetInt("score", i);
        }
    }

}
