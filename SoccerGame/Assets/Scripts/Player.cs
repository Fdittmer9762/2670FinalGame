using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //MOVEMENT
    public CharacterController playerCC;//contains the player transform
    Vector3 tempPos;

    //PLAYER STATS
    [HideInInspector] public string playerTeam;
    private int playerID;

    // EVENT SUBS
    private void OnEnable(){
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
