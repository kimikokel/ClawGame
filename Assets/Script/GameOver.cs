using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
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
            
            Debug.Log($"hit {testedTag}");
            EndGame();
            return;
        }
    }

    void EndGame()
    {
        print("gg");
        SceneManager.LoadScene("Main");
        StartGame.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
