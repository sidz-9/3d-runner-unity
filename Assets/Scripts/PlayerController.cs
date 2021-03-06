using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    
    [SerializeField]
    float speed;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector3.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
