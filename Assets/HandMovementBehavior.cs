using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovementBehavior : MonoBehaviour

{
    public Rigidbody2D rb;
    public Vector2 acceleration = new Vector2(0, .3f);
    public Vector2 currVelocity = new Vector2(0, 0);
    public Vector2 accelerationIncrease = new Vector2(0, .00001f);
    public AudioSource m_MyAudioSource;
    public GameObject Clock;
    public GameObject rightWall;
    public GameObject leftWall;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(0, 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        acceleration += accelerationIncrease;
        if(rb.velocity.y >= 0)
        {   
            rb.velocity += acceleration;
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {   
        if (col.gameObject.name == "Clock")
        {
            m_MyAudioSource.Stop();
            Time.timeScale = 0;
        }
        if(col.gameObject.name == "backWall")
        {
            rb.position = new Vector2(Random.Range(leftWall.transform.position.x + 2, rightWall.transform.position.x - 2), -35);
            rb.velocity = new Vector2(Clock.transform.position.x - rb.position.x, Random.Range(40, 50));
        }
        if(col.gameObject.name == "rightWall")
        {
            if(rb.velocity.y >= 0)
            {
                rb.velocity = new Vector2(Random.Range(-20, -10), Random.Range(40, 80));
            }
            if(rb.velocity.y < 0)
            {
                rb.velocity = new Vector2(Random.Range(-20,-10), Random.Range(40,80));
            }
        }
        if (col.gameObject.name == "leftWall")
        {
            if(rb.velocity.y >= 0)
            {
                rb.velocity = new Vector2(Random.Range(5, 10), Random.Range(40, 80));
            }
            if(rb.velocity.y < 0)
            {
                rb.velocity = new Vector2(Random.Range(5,10), Random.Range(40,80));
            }
        }
        if (col.gameObject.name == "frontWall")
        {
            rb.velocity = new Vector2(Clock.transform.position.x - rb.position.x, -40);
        }
        
        
    }
    
    void OnMouseDown()
    {
        rb.velocity = new Vector2(Random.Range(-5, 5), Random.Range(-40, -80));
    }
}
