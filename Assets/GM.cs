using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public GameObject leaderboard;
    public Transform player;
    // Start is called before the first frame update

        void Start()
    {
        Time.timeScale = 1.0f;
        BlackGate.Invisible();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    public void Reset()
    {
        Time.timeScale = 1.0f;
        BlackGate.Invisible();
        player.GetComponent<PlayerMovement>().Start();
        player.position = new Vector3(0, 1.9f, 1.29f);
        
        leaderboard.SetActive(false);
    }
}
