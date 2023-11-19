using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void ToggleMenu()
    {
        menu.SetActive(true);
    }

    public void ToggleClose()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
