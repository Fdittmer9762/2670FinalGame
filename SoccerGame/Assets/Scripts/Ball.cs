using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public GameObject ballGO;

    //EVENT SUBS
    private void OnEnable()
    {
        //takes player and target transform.pos info as vector 3's from the team manager
        PassBall(Vector3.right* 6, Vector3.left* 3);
    }

    private void OnDisable()
    {

    }

    void PassBall(Vector3 startPos, Vector3 endPos) {
        StartCoroutine (MoveBall( startPos, endPos, FindTravelTime(startPos,endPos)));
    }

    float FindTravelTime(Vector3 startPos, Vector3 endPos) { //finds the time needed to move the ball at a certain speed between two points
        float dist = Vector3.Distance(startPos, endPos);
        return dist / Statics.ballSpeed;
    }

    IEnumerator MoveBall(Vector3 startPos, Vector3 endPos, float travelTime) {
        float timeTraveled = 0f;
        float percentTraveled = 0f;
        while (percentTraveled < 1) {
            timeTraveled += Time.deltaTime;
            percentTraveled = timeTraveled / travelTime;
            ballGO.transform.position = Vector3.Lerp(startPos, endPos, percentTraveled); //try to replace with Slerp
            yield return null;
        }
    }
}