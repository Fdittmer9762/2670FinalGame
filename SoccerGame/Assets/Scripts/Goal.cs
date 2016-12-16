using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public string Team; //used to set ownership of the goal to determine who gets points
    public delegate void GoalScored(string teamName, int points);
    public static GoalScored OnGoalScored;

    void OnTriggerEnter() //when the ball enters the goal
    {
        Debug.Log("Goal " + Team);
        if(OnGoalScored != null) {
            OnGoalScored(Team, Statics.goalPointValue); //call event to add points, int is points to be added, team is who to add points to
        }
    }

}
