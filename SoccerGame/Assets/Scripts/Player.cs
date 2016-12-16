using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //EVENTS
    public delegate void TeamMember(string playerTeam, GameObject thisPlayer);
    public static TeamMember fillRoster;

    //MOVEMENT
    public CharacterController playerCC;//contains the player transform
    Vector3 tempPos;

    //PLAYER STATS
    public GameObject playerGO;
    public string playerTeam;
    private int playerID;


    // EVENT SUBS
    private void OnEnable() { //for setup
        if (fillRoster != null) { 
            fillRoster(playerTeam, playerGO); //adds player to the team
            Debug.Log("Attempting to add");
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
