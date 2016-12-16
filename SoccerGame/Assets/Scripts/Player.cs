using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //EVENTS

    //MOVEMENT
    private bool agentActive;
    public CharacterController playerCC;//contains the player transform
    private Vector3 tempPos;

    //PLAYER STATS
    public GameObject playerGO; //holds all the players needed info for later ref
    public string playerTeam;
    public int playerID;


    // EVENT SUBS
    private void OnEnable() { //for setup
        InputManagaer.PlayerInput += PlayerMovement;
        TeamManager.OnSwithcActiveControl += OnControlSwitch;
    }

    private void OnDisable()
    {
        InputManagaer.PlayerInput -= PlayerMovement;
        TeamManager.OnSwithcActiveControl -= OnControlSwitch;
    }

    void OnControlSwitch(int pID) {
        Debug.Log(playerID == pID);
        if (playerID == pID){ //may cause issues with C#'s wierd equivelance 
            InputManagaer.PlayerInput += PlayerMovement;
            //playerAgent.SetActive(false);
            agentActive = true;
        } else {
            InputManagaer.PlayerInput -= PlayerMovement;
            //playerAgent.SetActive(true);
            agentActive = false;
        }
    }

    void PlayerMovement(float inputH, float inputV) {
        Debug.Log(playerID + " " + agentActive);
        tempPos.x = inputH * Statics.playerSpeed * Time.deltaTime;
        tempPos.z = inputV * Statics.playerSpeed * Time.deltaTime;
        if (agentActive == false) {
            Debug.Log("null agent");
        }else {
            playerCC.Move(tempPos);
        }
    }

}
