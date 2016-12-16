using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public CharacterController playerCC;//contains the player transform
    Vector3 tempPos;

    // EVENT SUBS
    private void OnEnable(){
        InputManagaer.PlayerInput += PlayerMovement;
    }

    private void OnDisable()
    {
        InputManagaer.PlayerInput -= PlayerMovement;
    }

    void PlayerMovement(float inputH, float inputV) {
        Debug.Log(inputH + inputV);
        tempPos.x = inputH * Statics.playerSpeed;
        tempPos.z = inputV * Statics.playerSpeed;
        playerCC.Move(tempPos);
    }

}
