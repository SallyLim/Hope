using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockBehavior : MonoBehaviour
{   
    public AudioSource m_MyAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        m_MyAudioSource.Stop();
    }
}
