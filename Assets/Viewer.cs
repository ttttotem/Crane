using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewer : MonoBehaviour
{

    public MeshRenderer renderer;
    public bool visable;

    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    public void toggleVisable(){
        if (renderer != null)
        {
            if (renderer.enabled == true)
            {
                renderer.enabled = false;
            }
            else
            {
                renderer.enabled = true;
            }
        }
    }

    public void SetVisible()
    {
        if (renderer != null)
        {
            renderer.enabled = true;
        }
    }

    public void SetInvisible()
    {
        if (renderer != null)
        {
            renderer.enabled = false;
        }
    }
}
