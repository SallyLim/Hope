using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class textMovement : MonoBehaviour
{
    public GameObject textComponent1;
    public GameObject textComponent2;
    public GameObject textComponent3;
    public GameObject textComponent4;
    public GameObject targetText1;


    private float minSpeed = 1f;
    private float maxSpeed = 5f;
    private float frame = 0;
    

    void FixedUpdate()
    {
    //textComponent1.transform.position = Vector3.MoveTowards (textComponent1.transform.position, targetText1.transform.position, Time.deltaTime * Random.Range(minSpeed, maxSpeed));

    //textComponent2.transform.position = Vector3.MoveTowards (textComponent2.transform.position, targetText1.transform.position, Time.deltaTime * Random.Range(minSpeed, maxSpeed));

    //textComponent3.transform.position = Vector3.MoveTowards (textComponent3.transform.position, targetText1.transform.position, Time.deltaTime * Random.Range(minSpeed, maxSpeed));

    //textComponent4.transform.position = Vector3.MoveTowards (textComponent4.transform.position, targetText1.transform.position, Time.deltaTime * Random.Range(minSpeed, maxSpeed));

    //if (textComponent1.transform.position == targetText1.transform.position)

    if (frame <= 420)
    {
        frame ++;
    }
    else
    {
            SceneManager.LoadScene("Memorize2");
    }

    }

}
