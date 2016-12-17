using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour {

    //Team Management
    public GameObject[] RedTeam, BlueTeam;
    private int redTeamSize, blueTeamSize;
    public int controlledPlayer;

    //Passing Ball
    public GameObject redGoal, blueGoal;                                                //stores the transforms of goals

    //EVENTS
    public delegate void SwitchControl(int playerID);
    public static SwitchControl OnSwithcActiveControl;

    public delegate void PassBall(Vector3 ballStartPos, Vector3 ballEndPos);            //sends ball positions to move between to the ball Game Object
    public static PassBall OnBallPassed;

    private void OnEnable()
    {
        Player.OnButtonComand += OnTarget;                                              //subs to ball passing event series
        BallDetect.onInterception += OnBallPosChange;                                   //subs to controll change on interception event
    }

    private void OnDisable()
    {
        Player.OnButtonComand -= OnTarget;                                              //unsubs from ball passing event series
        BallDetect.onInterception -= OnBallPosChange;                                   //unsubs from ball interception event
    }

    //BALL PASSING
    void OnTarget (Vector3 playerPos, string Team){
        switch (Team) {
            case "Red":
                OnBallPassed(playerPos, redGoal.transform.position);
                break;
            case "Blue":
                OnBallPassed(playerPos, blueGoal.transform.position);
                break;
            case "Red Teammate":
                OnBallPassed(playerPos, FindClosestTeammate(RedTeam, playerPos)); 
                break;
            case "Blue Teammate":
                OnBallPassed(playerPos, FindClosestTeammate(BlueTeam, playerPos));
                break;
            default:
                Debug.Log("Something is wrong");
                break;
        }
    }

    private Vector3 FindClosestTeammate(GameObject[] Team, Vector3 playerPos) {
        GameObject adjTeammate = Team[0];                                               //needed to be assigned first, stores the game
        float dist;                                                                     //stores current GO distance to avoid mult calls of vector3.distance
        float shortestDist = 100f;                                                      //float stores the shortest distance
        for (int i = 0; i < Team.Length; i++) {                                         //iterrates throught the given array of GO
            dist = Mathf.Abs(Vector3.Distance(playerPos, Team[i].transform.position));  //finds the distance from player pos to ally
            if (dist != 0 && dist <= shortestDist) {                                    // if they are not in the same place and it is the new shortest
                shortestDist = dist;
                adjTeammate = Team[i];                                                  //save GO info as the closest ally
            }
        }
        return adjTeammate.transform.position; 
    }

    private void OnBallPosChange(string team, int player) {
        controlledPlayer = player;                                                      //changes controlled player
        if (OnSwithcActiveControl != null)
        {
            OnSwithcActiveControl(controlledPlayer);                                    //calls event to change controlled player, subs are in the player instances
        }
    }

    //AUTO ADD PLAYER / ROSTER FILLING  -----------------**Currently Not Needed**-------------------
    private int OnNewPlayer(string Team, GameObject player) { //decides which team to add the player to
        Debug.Log(Team + "string");
        switch (Team) {
            case "Red":
                return redTeamSize = AddPlayer(RedTeam, player, redTeamSize);
                //break;
            case "Blue":
                return blueTeamSize = AddPlayer(BlueTeam, player, blueTeamSize);
                //break;
            default:
                return 0;
                //break;
        }
    }

    private int AddPlayer(GameObject[] team, GameObject player, int playerCount) { //adds that player to the list
        if (team.Length <= playerCount){ //if there is a spot on the roster for the player
            team[playerCount] = player;// put player on the team
            playerCount++;
        }
        else {
            player.SetActive(false); //deactivate player **may replace with destroy
        }
        return playerCount;
    }

    //FOR TESTING
    private void DisplayPlayerPos(GameObject[] team)//TESTS IF ARRAY HOLDS THE PLAYERS POSITIONS
    {
        for (int i = 0; i < team.Length; i++)
        {
            Debug.Log(team[i].transform.position);
        }
    }
}
