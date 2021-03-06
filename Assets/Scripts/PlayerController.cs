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
    float jumpForce;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector3.forward * speed;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("jump");
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }
}
