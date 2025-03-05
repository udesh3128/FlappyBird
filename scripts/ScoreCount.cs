using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public Text Score;
    int i=0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        i++;
        Score.text = "SCORE:" + i;
    }
}
