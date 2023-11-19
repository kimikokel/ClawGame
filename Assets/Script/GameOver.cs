using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GG;
    public GameObject can;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider collision)
    {
        string[] tagToFind = new string[]{"Watermelon", "Meon", "Pineapple", "Peach", "Apple", "Pear", "Orange", "Citrus", "Grape", "Strawberry", "Cherry"};

        for(int i = 0; i < tagToFind.Length; i++)
        {
            var testedTag = tagToFind[i];
            if (!collision.CompareTag(testedTag)) continue;
            
            // Debug.Log($"hit {testedTag}");
            EndGame();
            return;
        }
    }

    void EndGame()
    {
        // if (!newBall) {
        Game.isDead = true;
        // print("gg");
        GG.SetActive(true);
        can.SetActive(false);
            // StartGame.score = 0;
        // } ///need fix if condition to end game fruit collide when newly spawn !!!!!!!!!!!!!!!
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey(KeyCode.Q))
        // {
        //     EndGame();
        // }
    }
}
