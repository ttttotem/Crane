using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

public class Gate : MonoBehaviour
{

    public static GameObject[] viewers;
    public AnalogGlitch analogGlitch;
    public DigitalGlitch digitalGlitch;

    private void Awake()
    {
        viewers = GameObject.FindGameObjectsWithTag("Obstacle");
    }

    private void OnTriggerEnter(Collider other)
    {
        RedGate.Invisible();
        if (other.tag == "Player")
        {
            Visable();
            analogGlitch.scanLineJitter = 0.15f;
            digitalGlitch.intensity = 0.1f;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        analogGlitch.scanLineJitter = 0f;
        digitalGlitch.intensity = 0f;
    }

    public static void Visable()
    {
        foreach (GameObject go in viewers)
        {
            Viewer view = go.GetComponent<Viewer>();
            if (view != null)
            {
                view.SetVisible();
            }
        }
    }

    public static void Invisible()
    {
        foreach (GameObject go in viewers)
        {
            Viewer view = go.GetComponent<Viewer>();
            if (view != null)
            {
                view.SetInvisible();
            }
        }
    }
}
