using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagaer : MonoBehaviour {

    public delegate void Inputs(float inputH, float vert);
    public static Inputs PlayerInput;

	//INPUT
	void Update () {
        Debug.Log("working");
        if (PlayerInput != null) {
            PlayerInput(Input.GetAxis("Horizontal")*Time.deltaTime, Input.GetAxis("Vertical")* Time.deltaTime);
        }
    }
}
