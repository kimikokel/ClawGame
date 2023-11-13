using UnityEngine;
using System.Collections;

public class ClawMovements : MonoBehaviour {

    public int maxHeight;
    public int minHeight;
    public GameObject Hook;
    public Animator clawAnimator;
    public float clawSpeed;
    Rigidbody rigidBody;

    public Transform HookHeight;

    public Transform leftLimit;
    public Transform rightLimit;
    public Transform frontLimit;
    public Transform backLimit;
    public bool CanControl;
    bool onSpace;
    bool isEmpty;

    public GameObject[] balls;
    public Transform clawPosition;
    GameObject newBall;

    void Awake(){
    }

    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        CanControl = true;
        onSpace = false;
        isEmpty = true;
        // Instantiate(balls[Random.Range(0,balls.Length)], clawPosition.position, clawPosition.rotation);
    }

    void Update() {
        if (CanControl) {

            if (transform.position.x > leftLimit.transform.position.x) {
                if (Input.GetKey(KeyCode.D)) {
                    transform.Translate(clawSpeed * -1 * Time.deltaTime, 0, 0);
                }
            }

            if (transform.position.x < rightLimit.transform.position.x) {
                if (Input.GetKey(KeyCode.A)) {
                    transform.Translate(clawSpeed * Time.deltaTime, 0, 0);
                }
            }

            if (transform.position.z < backLimit.transform.position.z) {
                if (Input.GetKey(KeyCode.S)) {
                    transform.Translate(0, 0, clawSpeed * Time.deltaTime);
                }
            }

            if (transform.position.z > frontLimit.transform.position.z) {
                if (Input.GetKey(KeyCode.W)) {
                    transform.Translate(0, 0, clawSpeed * -1 * Time.deltaTime);
                }
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                onSpace = true;
                CanControl = false;
                // isEmpty = true;
                // print("space "+ (int)HookHeight.position.y);
            }
        }

            if ((int)HookHeight.position.y >= minHeight && onSpace) {
                transform.Translate(0, (clawSpeed * -1f * Time.deltaTime), 0);
                // print("down "+ (int)HookHeight.position.y);
                clawAnimator.Play("open");
            }         


            if ((int)HookHeight.position.y == minHeight) {
                // print("==max");
                onSpace = false;
                StartCoroutine(closeClaw());
                // closeClaw();
                isEmpty = true;
            }

            if ((int)HookHeight.position.y == maxHeight && isEmpty) {
                // StartCoroutine(spawn(0.2f));
                isEmpty = false;
                newBall = Instantiate(balls[Random.Range(0,balls.Length)], clawPosition.position, clawPosition.rotation);
            }

            IEnumerator closeClaw() {
                // yield return new WaitForSeconds(secs); 
                yield return new WaitForSeconds(0.4f);
                if (HookHeight.position.y <= maxHeight && !onSpace && HookHeight.position.y > minHeight) {
                    // print("up");
                    transform.Translate(0, (clawSpeed * Time.deltaTime), 0);
                    CanControl = true;
                    yield return new WaitForSeconds(0.1f);
                    clawAnimator.Play("close");
                }
            }

            // void closeClaw() {
            //         if (HookHeight.position.y <= maxHeight && !onSpace && HookHeight.position.y > minHeight) {
            //             // print("up");
            //             transform.Translate(0, (clawSpeed * Time.deltaTime), 0);
            //             CanControl = true;
            //             clawAnimator.Play("close");
            //         }
            // }

            // IEnumerator spawn(float secs) {
            //     yield return new WaitForSeconds(secs);
            //     isEmpty = false;
            //     newBall = Instantiate(balls[Random.Range(0,balls.Length)], clawPosition.position, clawPosition.rotation);
            // }
    }
}     