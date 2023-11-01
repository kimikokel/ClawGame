using UnityEngine;
using System.Collections;

public class ClawMovements : MonoBehaviour {

    public float maxHeight;
    public float minHeight;
    public float tubeSeparationCorrection;

    public GameObject Tubes;
    public GameObject Motor;
    public GameObject Hook;
    public Animator clawAnimator;

    public float speed;
    public float clawSpeed;
    public float hookSpeed;
    Rigidbody rigidBody;

    public Transform HookHeight;

    // These are simple cubes used to define movement limits
    public Transform leftLimit;
    public Transform rightLimit;
    public Transform frontLimit;
    public Transform backLimit;

    public bool CanControl;
    bool ReleasePrize;

    public bool[] ArrivedAtBasket;

    bool insideBasket;

    bool lowerHookAndReleasePrize;

    bool raiseHookOutOfBasket;

    // Use this for initialization
    void Start () {
        // clawAnimator = Hook.gameObject.GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        CanControl = true;
        ReleasePrize = false;
    }

    // Update is called once per frame
    void Update() {
    }

    void FixedUpdate () {
        // Attach the motor's X/Z movement to the hook
        Motor.transform.position = new Vector3(transform.position.x, Motor.transform.position.y, transform.position.z);
        Tubes.transform.position = new Vector3(Tubes.transform.position.x, Tubes.transform.position.y, Motor.transform.position.z + tubeSeparationCorrection);

        // Release the prize
        if (ReleasePrize) {
            if (HookHeight.position.y <= maxHeight) {
                transform.Translate(0, clawSpeed * Time.deltaTime, 0);
            } else {
                // ArrivedAtBasket[0] = true;
            }

            if (transform.position.x >= leftLimit.transform.position.x + 0.5f) {
                // transform.Translate(speed * -1 * Time.deltaTime, 0, 0);
            } else {
                // ArrivedAtBasket[1] = true;
            }

            if (transform.position.z >= frontLimit.transform.position.z + 0.5f) {
                // transform.Translate(0, 0, speed * -1 * Time.deltaTime);
            } else {
                // ArrivedAtBasket[2] = true;
            }

            // Check if the hook is inside the basket
            if (true) {
                Debug.Log("Inside the basket");
                insideBasket = true;

                // Start a coroutine to lower the hook and release the prize
                if (insideBasket) {
                    StartCoroutine(ReleasePrizeInBasket(1.5f));
                    insideBasket = false;
                }
            }
        }

        if (lowerHookAndReleasePrize) {
            if (HookHeight.position.y > minHeight) {
                Debug.Log("Lowering");
                transform.Translate(0, clawSpeed * -1 * Time.deltaTime, 0);
            } else {
                StartCoroutine(OpenClawInBasket(0.5f));
                lowerHookAndReleasePrize = false;
            }
        }

        if (raiseHookOutOfBasket) {
            if (HookHeight.position.y <= maxHeight) {
                transform.Translate(0, clawSpeed * Time.deltaTime, 0);
            } else {
                CanControl = true;
                raiseHookOutOfBasket = false;
            }
        }

        if (CanControl) {
            // Lateral movements
            if (transform.position.x > leftLimit.transform.position.x) {
                if (Input.GetKey(KeyCode.A)) {
                    transform.Translate(speed * -1 * Time.deltaTime, 0, 0);
                }
            }

            if (transform.position.x < rightLimit.transform.position.x) {
                if (Input.GetKey(KeyCode.D)) {
                    transform.Translate(speed * Time.deltaTime, 0, 0);
                }
            }

            // Forward movements
            if (transform.position.z < backLimit.transform.position.z) {
                if (Input.GetKey(KeyCode.W)) {
                    transform.Translate(0, 0, speed * Time.deltaTime);
                }
            }

            if (transform.position.z > frontLimit.transform.position.z) {
                if (Input.GetKey(KeyCode.S)) {
                    transform.Translate(0, 0, speed * -1 * Time.deltaTime);
                }
            }

            // Lower the hook
            if (HookHeight.position.y > minHeight) {
                if (Input.GetKey(KeyCode.Space)) {
                    transform.Translate(0, hookSpeed * -1 * Time.deltaTime, 0);
                    print("rotate");
                    GameObject.FindWithTag("ClawBar").transform.Rotate(0.0f, 50.0f, 0.0f, Space.Self);
                }
            } else {
                StartCoroutine(CloseClaw(0.5f));
                CanControl = false;
            }
        }
    }

    // Coroutine to collect the prize
    IEnumerator CloseClaw(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        CloseClaw();
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Raising hook");
        ReleasePrize = true;
    }

    // Coroutine to release the prize
    IEnumerator ReleasePrizeInBasket(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        lowerHookAndReleasePrize = true;
        ReleasePrize = false;
        Debug.Log("Lowering hook");
        yield return new WaitForSeconds(waitTime);
    }

    // Coroutine to release the prize
    IEnumerator OpenClawInBasket(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        OpenClaw();
        yield return new WaitForSeconds(waitTime);
        raiseHookOutOfBasket = true;
    }

    public void OpenClaw() {
        Debug.Log("Opening Hook");
        // clawAnimator.SetBool("Open", true);
        // clawAnimator.SetBool("Close", false);
    }

    public void CloseClaw() {
        Debug.Log("Closing Hook");
        // clawAnimator.SetBool("Open", false);
        // clawAnimator.SetBool("Close", true);
    }
}

// using UnityEngine;
// using System.Collections;

// public class ClawMovements : MonoBehaviour {

//     public float maxHeight;
//     public float minHeight;
//     public float tubeSeparationCorrection;

//     public GameObject Tubes;
//     public GameObject Motor;
//     public GameObject Hook;
//     public Animator clawAnimator;

//     public float speed;
//     public float clawSpeed;
//     Rigidbody rigidBody;

//     public Transform HookHeight;

//     public Transform leftLimit;
//     public Transform rightLimit;
//     public Transform frontLimit;
//     public Transform backLimit;

//     public bool CanControl;
//     bool ReleasePrize;

//     // Use this for initialization
//     void Start () {
//         clawAnimator = Hook.gameObject.GetComponent<Animator>();
//         rigidBody = GetComponent<Rigidbody>();
//         CanControl = true;
//         ReleasePrize = false;
//     }

//     // Update is called once per frame
//     void Update() {
//         // Handle player controls for movement
//         if (CanControl) {
//             // Movements
//             float horizontalInput = Input.GetAxis("Horizontal");
//             float verticalInput = Input.GetAxis("Vertical");

//             // Move the claw horizontally and forward/backward
//             Vector3 movement = new Vector3(horizontalInput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime);
//             transform.Translate(movement);

//             // Lower the Claw
//             if (Input.GetKey(KeyCode.Space) && HookHeight.position.y > minHeight) {
//                 transform.Translate(0, clawSpeed * -1 * Time.deltaTime, 0);
//             } else if (ReleasePrize) {
//                 // Raise the claw after releasing the prize
//                 if (HookHeight.position.y < maxHeight) {
//                     transform.Translate(0, clawSpeed * Time.deltaTime, 0);
//                 } else {
//                     ReleasePrize = false; // Reset the flag
//                 }
//             }
//         }
//     }

//     // Coroutine to collect the prize
//     IEnumerator CloseClaw(float waitTime) {
//         yield return new WaitForSeconds(waitTime);
//         CloseClaw();
//         yield return new WaitForSeconds(waitTime);
//         Debug.Log("Raising hook");
//         ReleasePrize = true;
//     }

//     public void OpenClaw() {
//         Debug.Log("Opening Hook");
//         // clawAnimator.SetBool("Open", true);
//         // clawAnimator.SetBool("Close", false);
//     }

//     public void CloseClaw() {
//         Debug.Log("Closing Hook");
//         // clawAnimator.SetBool("Open", false);
//         // clawAnimator.SetBool("Close", true);
//     }
// }
