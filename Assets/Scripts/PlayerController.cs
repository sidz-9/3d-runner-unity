using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    
    [SerializeField]
    float speed;

    [SerializeField]
    float horizontalMovementMultiplier = 2f;
    float horizontalInput;

    [SerializeField]
    float jumpForce;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // rb.velocity = Vector3.forward * speed;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("jump");
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        // Vector3 horizontalMove = transform.right * horizontalInput * speed * horizontalMovementMultiplier * Time.deltaTime;
        // rb.MovePosition(rb.position + horizontalMove);

        // float deltaX = Input.GetAxis("Horizontal") * speed;
        // transform.Translate(deltaX * Time.deltaTime, 0, 0);

        
    }

    void FixedUpdate() {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMovementMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
}
