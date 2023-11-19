using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam : MonoBehaviour
{
    public Camera front;
    private Vector3 frontPos;
    private Vector3 frontAng;

    void Start()
    {
        frontPos = front.transform.position;
        frontAng = front.transform.eulerAngles;
        // back.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void changeView()
    {
        front.transform.position = frontPos;
        front.transform.eulerAngles = frontAng;
        // if (front.enabled)
        // {
        //     front.enabled = false;
        // }
        // else
        // {
        //     front.enabled = true;
        // }
    }
}
