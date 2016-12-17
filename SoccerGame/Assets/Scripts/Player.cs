using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //EVENTS
    public delegate void ButtonPress (Vector3 playerPos, string passTarget);
    public static ButtonPress OnButtonComand;

    public delegate void ParentBall(GameObject newParent);
    public static ParentBall onParentChange;

    //MOVEMENT
    private bool agentActive;
    public CharacterController playerCC;                                        //contains the player transform
    private Vector3 tempPos;

    //PLAYER STATS
    public GameObject playerGO;                                                 //holds all the players needed info for later ref
    public string playerTeam;
    public int playerID;


    // EVENT SUBS
    private void OnEnable() {                                                   //for setup
        InputManagaer.PlayerInput += PlayerMovement;
        InputManagaer.KeyPressed += OnButtonPress;
        TeamManager.OnSwithcActiveControl += OnControlSwitch;
    }

    private void OnDisable()
    {
        InputManagaer.PlayerInput -= PlayerMovement;
        InputManagaer.KeyPressed -= OnButtonPress;
        TeamManager.OnSwithcActiveControl -= OnControlSwitch;
    }

    void OnControlSwitch(int pID) {
        Debug.Log(playerID == pID);
        if (playerID == pID){
            InputManagaer.PlayerInput += PlayerMovement;
            InputManagaer.KeyPressed += OnButtonPress;
            agentActive = true;
            //pass gameobject to ball to parent
            if (onParentChange != null) {
                onParentChange(playerGO);
            }
        } else {
            InputManagaer.PlayerInput -= PlayerMovement;
            InputManagaer.KeyPressed -= OnButtonPress;
            agentActive = false;
        }
    }

    void PlayerMovement(float inputH, float inputV) {
        tempPos.x = inputH * Statics.playerSpeed * Time.deltaTime;
        tempPos.z = inputV * Statics.playerSpeed * Time.deltaTime;
        if (agentActive == false) {
            Debug.Log("null agent");
        }else {
            playerCC.Move(tempPos);
        }
    }

    void OnButtonPress(string pressedButton) {
        //unparent the ball from the player, somewhere down the line
        switch (pressedButton) {
            case "G":
                if (OnButtonComand != null) {
                    OnButtonComand(playerGO.transform.position, playerTeam);
                }
                break;
            case "F":
                if (OnButtonComand != null){
                    OnButtonComand(playerGO.transform.position, playerTeam + " Teammate");
                }
                break;
        }
    }

}
