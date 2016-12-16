using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour {

    public GameObject[] RedTeam, BlueTeam;
    private int redTeamSize, blueTeamSize;
    public int controlledPlayer;

    //EVENTS
    public delegate void SwitchControl(int playerID);
    public static SwitchControl OnSwithcActiveControl;

    private void OnEnable()
    {
        if(OnSwithcActiveControl != null) {
            OnSwithcActiveControl(controlledPlayer);
            Debug.Log("not Null");
        }
        else { Debug.Log("Null");}
    }

    private void OnDisable()
    {

    }

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
