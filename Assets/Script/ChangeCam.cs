using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam : MonoBehaviour
{
    public Camera front;
    public Camera back;

    // [SerializeField] private Button btn = null;
    // Start is called before the first frame update
    void Start()
    {
        front.enabled = true;
        // back.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void changeView()
    {
        if (front.enabled)
        {
            front.enabled = false;
        }
        else
        {
            front.enabled = true;
        }
    }
}
