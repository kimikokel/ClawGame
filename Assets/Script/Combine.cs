using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Combine : MonoBehaviour
{
    private GameObject ball;
    private int nextBall;
    public GameObject[] newBall;
    private GameObject newIns;
    private GameObject currentBall;

    // void UpdateScoreDisplay()
    // {
    //     if (scoreText != null)
    //     {
    //         // scoreText.text = StartGame.score.ToString();
    //         // // scoreDead.text = StartGame.score.ToString();
    //         // Debug.Log("Updated Score Display. Current Score: " + StartGame.score);
    //     }
    //     else
    //     {
    //         // Debug.LogError("scoreText is not assigned!");
    //     }
    // }

    void Start()
    {
        // scoreText = GameObject.Find("ScoreUI").GetComponent<TMP_Text>();
        // // scoreDead = GameObject.Find("ScoreDead").GetComponent<TMP_Text>();
        // StartGame.score = int.Parse(scoreText);
        ball = gameObject;
        // UpdateScoreDisplay();
        // isSpawned = false;
    }
    //ball = self
    //target = the one i touched
    //currentball = the one i touched
    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == ball.tag && !Game.isDead)
        {
            // StartCoroutine(Spawn());
            ball.tag = "Dead";
            // spawn();
            if (!Game.isDead)
                Next(target.gameObject.tag);
            // isSpawned = false;

            if (ball.tag == "Dead")
            {
                Destroy(ball);
                Destroy(target.gameObject);
                newIns = Instantiate(newBall[nextBall], transform.position, transform.rotation);
                // UpdateScoreDisplay();
                // StartCoroutine(Spawn());
                // isSpawned = true;
            }
        }
    }

    // IEnumerator Spawn() {
    //     print("FUCKUFRONT");
    //     yield return new WaitForSeconds(5f);
    //     print("FUCKUBACk");
    //     // newIns = Instantiate(newBall[nextBall], transform.position, transform.rotation);
    // }

    void Next(string current)
    {
        switch (current)
        {
            case "Cherry":
                // print("current: " + current);
                nextBall = 9;
                StartGame.score += 1;
                // print("next: " + nextBall);
                break;
            case "Strawberry":
                // print("current: " + current);
                nextBall = 8;
                StartGame.score += 3;
                // print("next: " + nextBall);
                break;
            case "Grape":
                // print("current: " + current);
                nextBall = 7;
                StartGame.score += 6;
                // print("next: " + nextBall);
                break;
            case "Citrus":
                // print("current: " + current); 191 206 255
                nextBall = 6;
                StartGame.score += 10;
                break;
            case "Orange":
                // print("current: " + current);
                nextBall = 5;
                StartGame.score += 25;
                break;
            case "Apple":
                nextBall = 4;
                StartGame.score += 30;
                break;
            case "Pear":
                nextBall = 3;
                StartGame.score += 50;
                break;
            case "Peach":
                nextBall = 2;
                StartGame.score += 60;
                break;
            case "Pineapple":
                nextBall = 1;
                StartGame.score += 80;
                break;
            case "Melon":
                nextBall = 0;
                StartGame.score += 100;
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
