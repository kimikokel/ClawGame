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
    // private bool isSpawned;

    // Start is called before the first frame update
    void Start()
    {
        ball = gameObject;
        // next(ball);
        // isSpawned = false;
    }
    //ball = self
    //target = the one i touched
    //currentball = the one i touched
    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == ball.tag)
        {
            ball.tag = "Dead";
            // spawn();
            Next(target.gameObject.tag);
            // isSpawned = false;

            if (ball.tag == "Dead")
            {
                Destroy(ball);
                Destroy(target.gameObject);
                newIns = Instantiate(newBall[nextBall], transform.position, transform.rotation);
                // isSpawned = true;
            }
        }
    }

    void Next(string current)
    {
        switch (current)
        {
            case "Cherry":
                // print("current: " + current);
                nextBall = 9;
                // print("next: " + nextBall);
                break;
            case "Strawberry":
                // print("current: " + current);
                nextBall = 8;
                // print("next: " + nextBall);
                break;
            case "Grape":
                // print("current: " + current);
                nextBall = 7;
                // print("next: " + nextBall);
                break;
            case "Citrus":
                // print("current: " + current);
                nextBall = 6;
                break;
            case "Orange":
                // print("current: " + current);
                nextBall = 5;
                break;
            case "Apple":
                nextBall = 4;
                break;
            case "Pear":
                nextBall = 3;
                break;
            case "Peach":
                nextBall = 2;
                break;
            case "Pineapple":
                nextBall = 1;
                break;
            case "Melon":
                nextBall = 0;
                break;
            default:
                print("NOPE");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // isSpawned = true;

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
