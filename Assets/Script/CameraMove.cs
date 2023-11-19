using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed;
    public float yaw;
    public float pitch;

    private Vector3 pos;
    float rX;
    float rY;
    float rZ;

    // Start is called before the first frame update
    void Start()
    {
        speed = 300f;
        // yaw = 0f;
        // pitch = 0f;
        print("start");
        pos = transform.position;
        rX = transform.eulerAngles.x;
        rY = transform.eulerAngles.y;
        rZ = transform.eulerAngles.z;
        // rZ = gameObject.transform.rotation.z;
    }

    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            float verInput = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
            float horInput = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
            // transform.Rotate(Vector3.right, verInput);
            // transform.Rotate(Vector3.up, horInput, Space.World);
            // transform.RotateAround(new Vector3(0,0,0), Vector3.up, verInput);
            transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, horInput);
            // print(Space.World);
        }
        // if (Input.GetButtonUp("Fire2"))
        // {
        //     print("pos: " + pos);
        //     transform.eulerAngles = new Vector3(rX, rY, rZ);
        //     transform.position = pos;
        //     // transform.Rotate(rX, rY, rZ);
        // }
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetButton("Fire1"))
    //     {
    //         Vector3 mousePos = Input.mousePosition;
    //         {
    //             yaw += speed * Input.GetAxis("Mouse X");
    //             pitch -= speed * Input.GetAxis("Mouse Y");

    //             // yaw = Mathf.Clamp(yaw, -90f, 90f);
    //             //the rotation range
    //             // pitch = Mathf.Clamp(pitch, -60f, 90f);
    //             //the rotation range

    //             transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    //             // transform.Rotation = rot;

    //         }
    //     }
    // }
}
