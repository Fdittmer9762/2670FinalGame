using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour {

    protected int RedScore, BlueScore;

    private void OnEnable(){
        Goal.OnGoalScored += AddPoints;
    }

    private void OnDisable()
    {
        Goal.OnGoalScored -= AddPoints;
    }

    private void AddPoints(string team, int points) {
        switch (team) {
            case "Red":
                RedScore += points;
                break;
            case "Blue":
                BlueScore += points;
                break;
            default:
                Debug.Log("Error No Points Added");
                break;
        }
        Debug.Log(team + " Scored " + points + " points!");
        Debug.Log("R: " + RedScore + "vs B: " + BlueScore);
    }

}
