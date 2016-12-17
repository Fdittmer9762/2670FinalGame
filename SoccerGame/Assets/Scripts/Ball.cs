using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public GameObject ballGO;
    private bool ballIsPassable = true;

    //EVENT SUBS
    private void OnEnable()
    {
        TeamManager.OnBallPassed += PassBall;                                               //takes player and target transform.pos info as vector 3's from the team manager
        Player.onParentChange += ChangeParent;
    }

    private void OnDisable()
    {
        TeamManager.OnBallPassed -= PassBall;
        Player.onParentChange -= ChangeParent;
    }

    //BALL PASSING/MOVEMENT
    void PassBall(Vector3 startPos, Vector3 endPos) {
        if (ballIsPassable) {
        StartCoroutine (MoveBall( startPos, endPos, FindTravelTime(startPos,endPos)));
        }
    }

    float FindTravelTime(Vector3 startPos, Vector3 endPos) {                                //finds the time needed to move the ball at a certain speed between two points
        float dist = Vector3.Distance(startPos, endPos);
        return dist / Statics.ballSpeed;
    }

    IEnumerator MoveBall(Vector3 startPos, Vector3 endPos, float travelTime) {
        ballIsPassable = false;
        float timeTraveled = 0f;
        float percentTraveled = 0f;
        while (percentTraveled < 1) {
            timeTraveled += Time.deltaTime;
            percentTraveled = timeTraveled / travelTime;
            ballGO.transform.position = Vector3.Lerp(startPos, endPos, percentTraveled);    //try to replace with Slerp
            yield return null;
        }
        ballIsPassable = true;
    }

    void ChangeParent(GameObject newParent) {
        ballGO.transform.SetParent(newParent.transform);                                    //sets parent to controlled player
    }
}