using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour {

    protected int RedScore, BlueScore;

    private void OnEnable(){
        Goal.OnGoalScored += AddPoints;
    }

    private void AddPoints(string team, int points) {
        switch (team) {
            case "Red":
                break;
            case "Blue":
                break;
        }
    }

}
