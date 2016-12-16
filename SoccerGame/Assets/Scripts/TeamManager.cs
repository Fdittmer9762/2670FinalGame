using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour {

    private List<GameObject> RedTeam, BlueTeam;

    private void Start()
    {
        Player.fillRoster += OnNewPlayer;
    }

    private void OnDisable()
    {
        Player.fillRoster -= OnNewPlayer;
    }

    private void OnNewPlayer(string Team, GameObject player) { //decides which team to add the player to
        Debug.Log(Team + "string");
        switch (Team) {
            case "Red":
                AddPlayer(RedTeam, player);
                break;
            case "Blue":
                AddPlayer(BlueTeam, player);
                break;
            default:
                break;
        }
    }

    private void AddPlayer(List<GameObject> Team, GameObject player) { //adds that player to the list
        Team.Add(player);
        Debug.Log(Team + " team now has " + Team.Count + "Players");
    }
}
