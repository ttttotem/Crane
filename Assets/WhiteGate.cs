using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteGate : MonoBehaviour
{   private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Visable();
        }
    }

    public static void Visable()
    {
        Gate.Visable();
        RedGate.Visable();
    }
}
