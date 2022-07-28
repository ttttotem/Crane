using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using UnityEngine.UI;

public class Login : MonoBehaviour
{

    public Score score;
    public GameObject leaderboard;
    public Text[] points;
    public string memberID = "";

    public void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");
            memberID = response.player_id.ToString();
        });
    }

    public void SubmitScore()
    {
        if (memberID == "")
        {
            return;
        }
        int leaderboardID = 3481;
        int new_score = score.GetScore(); 

        LootLockerSDKManager.SubmitScore(memberID, new_score, leaderboardID.ToString(), (response) =>
        {
            if (response.statusCode == 200)
            {
                Debug.Log("Successful");
            }
            else
            {
                Debug.Log("failed: " + response.Error);
            }
        });
        GetScores();
    }

    public void GetScores()
    {
        int leaderboardID = 3481;

        LootLockerSDKManager.GetMemberRank(leaderboardID.ToString(), memberID, (response) =>
        {
            if (response.statusCode == 200)
            {
                int rank = response.rank;
                int count = 10;
                int after = rank < 6 ? 0 : rank - 5;

                LootLockerSDKManager.GetScoreListMain(leaderboardID, count, after, (response) =>
                {
                    if (response.statusCode == 200)
                    {
                        Debug.Log("Successful");
                        Debug.Log(response.text);
                        LeaderBoard(response.items);
                    }
                    else
                    {
                        Debug.Log("failed: " + response.Error);
                    }
                });
            }
            else
            {
                Debug.Log("failed: " + response.Error);
            }
        });
    }

    public void LeaderBoard(LootLocker.Requests.LootLockerLeaderboardMember[] members)
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i].color = Color.white;
        }

        for (int i = 0; i < members.Length; i++)
        {
            if (i < points.Length)
            {
                points[i].text = members[i].score.ToString();
                if(members[i].member_id == memberID)
                {
                    points[i].color = Color.green;
                }
            }
        }
        leaderboard.SetActive(true);
    }
}
