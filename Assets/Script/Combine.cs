using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour
{
    private GameObject ball;
    private int nextBall;
    public GameObject[] newBall;
    private GameObject newIns;
    private GameObject currentBall;
    private bool isSpawned;

    // Start is called before the first frame update
    void Start()
    {
        ball = gameObject;
        // next(ball);
        isSpawned = false;
    }
    //ball = self
    //target = the one i touched
    //currentball = the one i touched
    void OnCollisionEnter(Collision target) {
        if (target.gameObject.tag == ball.tag){
            ball.tag = "Dead";
            // spawn();
            next(target.gameObject.tag);
            isSpawned = false;

            if (ball.tag == "Dead") {
                Destroy(ball);
                Destroy(target.gameObject);
                newIns = Instantiate(newBall[nextBall], transform.position, transform.rotation);
                isSpawned = true;
            }
        }
    }

    void next(string current) {
        switch (current) {
            case "Purple":
                // print("current: " + current);
                nextBall = 1;
                // print("next: " + nextBall);
                break;
            case "Red":
                // print("current: " + current);
                nextBall = 2;
                // print("next: " + nextBall);
                break;
            case "Orange":
                // print("current: " + current);
                nextBall = 3;
                // print("next: " + nextBall);
                break;
            case "Pink":
                // print("current: " + current);
                nextBall = 4;
                break;
            case "Yellow":
                // print("current: " + current);
                nextBall = 5;
                break;
            case "Lightgreen":
                nextBall = 6;
                break;
            case "Green":
                nextBall = 7;
                break;
            default:
                // nextBall = 0;
                print("NOPE");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        isSpawned = true;

        // print("crball = " + currentBall);
        // print("newins = " + newIns);
        // print("issp = " + isSpawned);
        // if (!isSpawned && newIns != currentBall) {
        //     print("enter spawn");
        //     // newIns = Instantiate(newBall[nextBall], transform.position, transform.rotation);
        //     currentBall = newIns;
        //     isSpawned = true;
        // }
    }

}
