using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text scoreDead;
    public static bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        scoreText = GameObject.Find("ScoreUI").GetComponent<TMP_Text>();
        scoreDead = GameObject.Find("ScoreDead").GetComponent<TMP_Text>();

        GameObject.Find("GG").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = StartGame.score.ToString();
        scoreDead.text = StartGame.score.ToString();
    }
}
