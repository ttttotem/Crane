using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackGate : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Invisible();
        }
    }

    public static void Invisible()
    {
        Gate.Invisible();
        RedGate.Invisible();
    }
}
