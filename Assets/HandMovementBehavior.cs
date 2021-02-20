using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovementBehavior : MonoBehaviour

{
    public Rigidbody2D rb;
    public Vector2 acceleration = new Vector2(.002f, 0);
    public Vector2 currVelocity = new Vector2(0, 0);
    public Vector2 accelerationIncrease = new Vector2(0.00001f, 0);
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(5, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        acceleration += accelerationIncrease;
        if(rb.velocity.x >= 0)
        {   
            rb.velocity += acceleration;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {   
        if (col.gameObject.name == "Clock")
        {
            Time.timeScale = 0;
        }
        if(col.gameObject.name == "backWall")
        {
            rb.velocity = new Vector2(Random.Range(10, 20), Random.Range(-3, 3));
        }
        if(col.gameObject.name == "topWall")
        {
        }
        if (col.gameObject.name == "bottomWall")
        {
        }
        if (col.gameObject.name == "frontWall")
        {
            rb.velocity = new Vector2(-10, Random.Range(-5, 5));
        }
        
        
    }
    
    void OnMouseDown()
    {
        rb.velocity = new Vector2(-10, Random.Range(-5, 5));
    }
}
