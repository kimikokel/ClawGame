using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

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
    public GameObject newBall;

    [SerializeField]
    AudioSource pop;


    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        CanControl = true;
        onSpace = false;
        isEmpty = true;
        newBall = Instantiate(balls[Random.Range(0,balls.Length)], clawPosition.position, clawPosition.rotation);
    }

    void Update() {
        if (CanControl && !Game.isDead) {

            Vector3 pos = GameObject.Find("Main Camera").transform.position;
            Vector3 vz = new Vector3(-pos.x, 0, -pos.z);
            Vector3 vx = Quaternion.AngleAxis(-90, Vector3.up) * vz;
            vz.Normalize();
            vx.Normalize();
            Vector3 offset = Vector3.zero;

            if (Input.GetKey(KeyCode.D)) {
                // transform.Translate(clawSpeed * -1 * Time.deltaTime, 0, 0);
                offset += (-vx * clawSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A)) {
                // transform.Translate(clawSpeed * Time.deltaTime, 0, 0);
                offset += (vx * clawSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S)) {
                // transform.Translate(0, 0, clawSpeed * Time.deltaTime);
                offset += (-vz * clawSpeed * Time.deltaTime);        
            }
            if (Input.GetKey(KeyCode.W)) {
                // transform.Translate(0, 0, clawSpeed * -1 * Time.deltaTime);
                offset += (vz * clawSpeed * Time.deltaTime);
            }                


            Vector3 newPos = transform.position + offset;

            if (newPos.x > leftLimit.transform.position.x &&
                newPos.x < rightLimit.transform.position.x &&
                newPos.z < backLimit.transform.position.z &&
                newPos.z > frontLimit.transform.position.z
            ) {
                transform.position = newPos;
            }


            // if (transform.position.x < rightLimit.transform.position.x) {
            //     if (Input.GetKey(KeyCode.A)) {
            //         // transform.Translate(clawSpeed * Time.deltaTime, 0, 0);
            //         transform.position += (vx * clawSpeed * Time.deltaTime);
            //     }
            // }

            // if (transform.position.z < backLimit.transform.position.z) {
            //     if (Input.GetKey(KeyCode.S)) {
            //         // transform.Translate(0, 0, clawSpeed * Time.deltaTime);
            //         transform.position += (-vz * clawSpeed * Time.deltaTime);        
            //     }
            // }

            // if (transform.position.z > frontLimit.transform.position.z) {
            //     if (Input.GetKey(KeyCode.W)) {
            //         // transform.Translate(0, 0, clawSpeed * -1 * Time.deltaTime);
            //         transform.position += (vz * clawSpeed * Time.deltaTime);
            //     }
            // }

            if (Input.GetKeyDown(KeyCode.Space) && !Game.isDead) {
                onSpace = true;
                CanControl = false;
                pop.Play();
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

            if ((int)HookHeight.position.y == maxHeight && isEmpty && clawAnimator.GetCurrentAnimatorStateInfo(0).IsName("close")) {
                // StartCoroutine(spawn(0.4f));
                isEmpty = false;
                newBall = Instantiate(balls[Random.Range(0,balls.Length)], clawPosition.position, clawPosition.rotation);
            }

            IEnumerator closeClaw() {
                // yield return new WaitForSeconds(secs); 
                yield return new WaitForSeconds(0.2f);
                if (HookHeight.position.y <= maxHeight && !onSpace && HookHeight.position.y > minHeight) {
                    // print("up");
                    transform.Translate(0, (clawSpeed * Time.deltaTime), 0);
                    CanControl = true;
                    yield return new WaitForSeconds(0.1f);
                    clawAnimator.Play("close");
                }
            }
    }
}     