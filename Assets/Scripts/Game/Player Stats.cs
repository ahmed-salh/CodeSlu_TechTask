using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int score;

    public int highScore;

    public void AddScore()
    {
        score++;
        if (score >= highScore) 
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }
    }

}
