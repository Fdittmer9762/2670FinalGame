using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagaer : MonoBehaviour {

    public delegate void Inputs(float inputH, float vert);
    public static Inputs PlayerInput;

	//INPUT
	void Update () {
        if (PlayerInput != null) {
            PlayerInput(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }
}
