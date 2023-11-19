using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        // score = 0;
    }

    public void enterMain()
    {
        Game.isDead = false;
        score = 0;
        print("entermain");
        SceneManager.LoadScene("Main");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
