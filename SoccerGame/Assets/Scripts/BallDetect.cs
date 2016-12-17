using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetect : MonoBehaviour {

    public string team;
    public int playerID;

    public delegate void Interception(string team, int ID);
    public static event Interception onInterception;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ball int");
        if (onInterception != null) {
            onInterception(team, playerID);
        }
    }

}
