using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private void Awake() {

        rb = GetComponent<Rigidbody2D>();

    }

    private void Start() {
        
        rb.gravityScale = 0;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
           Invoke("GravityOn", 1.5f);
        }

        if (col.gameObject.tag == "BelowBarrier")
        {
           Destroy(gameObject);
        }


	}

    private void GravityOn(){

        rb.gravityScale = 1;

    }
}
