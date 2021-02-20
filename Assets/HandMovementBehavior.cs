using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovementBehavior : MonoBehaviour

{
    public Rigidbody2D rb;
    public Vector2 acceleration = new Vector2(.02f, 0);
    public Vector2 currVelocity = new Vector2(0, 0);
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        currVelocity += acceleration;
        if(rb.velocity.x >= 0)
        {   
            rb.velocity += acceleration;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {   
        rb.velocity = new Vector2(0,0);
        if(col.gameObject.tag == "backWall")
        {
            rb.velocity = new Vector2(Random.Range(-3, 3), Random.Range(5, 20));
        }
        
        Debug.Log(col);
    }
    
    void OnMouseDown()
    {
        rb.velocity = new Vector2(-20, Random.Range(-3, 3));
    }
}
