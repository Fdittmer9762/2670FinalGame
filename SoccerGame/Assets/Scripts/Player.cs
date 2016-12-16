using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //EVENTS
    public delegate int TeamMember(string playerTeam, GameObject playerGO);
    public static TeamMember fillRoster;

    //MOVEMENT
    public CharacterController playerCC;//contains the player transform
    Vector3 tempPos;

    //PLAYER STATS
    public GameObject playerGO; //holds all the players needed info for later ref
    public string playerTeam;
    public int playerID;


    // EVENT SUBS
    private void OnEnable() { //for setup
        if (fillRoster != null) { 
            playerID = fillRoster(playerTeam, playerGO); //adds player to the team, sets player id
        }
        InputManagaer.PlayerInput += PlayerMovement;
    }

    private void OnDisable()
    {
        InputManagaer.PlayerInput -= PlayerMovement;
    }

    void PlayerMovement(float inputH, float inputV) {
        tempPos.x = inputH * Statics.playerSpeed * Time.deltaTime;
        tempPos.z = inputV * Statics.playerSpeed * Time.deltaTime;
        playerCC.Move(tempPos);
    }

}
