using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public Transform player;
    public int RealScore = 0;
    public Login login;

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (player.position.y < 0.5)
        {
            if (player.position.y < -148)
            {
                if (Time.timeScale != 0)
                {
                    login.SubmitScore();
                }
                Time.timeScale = 0;
            }
            WhiteGate.Visable();
        } else
        {
            RealScore = (int)player.position.z;
            score.text = RealScore.ToString();
        }
    }

    public int GetScore()
    {
        return RealScore;
    }
}
