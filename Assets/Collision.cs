using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    public Login login;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.collider.tag == "Obstacle" || collision.collider.tag == "Red Obstacle")
        {
            WhiteGate.Visable();
            Time.timeScale = 0;
            login.SubmitScore();
        }
    }
}
