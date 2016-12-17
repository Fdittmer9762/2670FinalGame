using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagaer : MonoBehaviour {

    public string goalCommand = "G", passComand = "F";

    public delegate void Inputs(float inputH, float vert);
    public static Inputs PlayerInput;

    public delegate void KeyInputs(string key);
    public static KeyInputs KeyPressed;

	//INPUT
	void Update () {
        if (PlayerInput != null) {
            PlayerInput(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        if (KeyPressed != null) {
            if (Input.GetKeyDown(KeyCode.G)) {
                KeyPressed(goalCommand);
                Debug.Log("G");
            }
            if (Input.GetKeyDown(KeyCode.F)){
                KeyPressed(passComand);
                Debug.Log("F");
            }
        }
    }
}
