using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // CapsuleCollider _capsuleCollider;

    public float rotateSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        // _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void Update() {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);   // to make the coins rotate
    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player") {
            Destroy(gameObject);

            // increment coin score
            ScoreController.instance.IncrementCoinScore();
        }
    }
}
