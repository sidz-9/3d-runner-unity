using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;

    public Swipe swipeControls;

    [SerializeField]
    float speed;

    [SerializeField]
    float horizontalMovementMultiplier = 2f;
    float horizontalInput;

    [SerializeField]
    float jumpForce;

    bool isAlive;

    bool isJumping = false;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // rb.velocity = Vector3.forward * speed;
        isAlive = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive && !FellToDeath()) {
            ScoreController.instance.score = transform.position.z / 10f;
            UiController.instance.scoreText.text = (transform.position.z / 10f).ToString("0") + "m";

            if(swipeControls.SwipeDown) {
                Debug.Log("SwipeDown");
            }

            // if(Input.GetMouseButtonDown(0) && !isJumping)
            if(swipeControls.SwipeUp && !isJumping)
            {
                Debug.Log("Jump");
                isJumping = true;
                anim.SetTrigger("jump");
                rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            }

            horizontalInput = Input.GetAxis("Horizontal");
            // Vector3 horizontalMove = transform.right * horizontalInput * speed * horizontalMovementMultiplier * Time.deltaTime;
            // rb.MovePosition(rb.position + horizontalMove);

            // float deltaX = Input.GetAxis("Horizontal") * speed;
            // transform.Translate(deltaX * Time.deltaTime, 0, 0);
        }
        else {
            Invoke("GameOver", 1f);
        }   
    }

    void FixedUpdate() {
        if(isAlive && !FellToDeath()) {
            Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
            Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMovementMultiplier;
            rb.MovePosition(rb.position + forwardMove + horizontalMove);
        }
        else {
            Invoke("GameOver", 1f);
        }
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Obstacle") {
            isAlive = false;
            Invoke("GameOver", 1f);
        }

        if(col.gameObject.tag == "Ground") {
            isJumping = false;
        }
    }

    bool FellToDeath() {
        if(transform.position.y < -5f)
        {
            rb.isKinematic = true;
            return true;
        }
        return false;
    }

    void GameOver() {
        GameController.instance.StopGame();
    }
}
