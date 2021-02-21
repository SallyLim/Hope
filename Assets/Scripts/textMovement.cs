using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textMovement : MonoBehaviour
{
    public GameObject textComponent;
    public GameObject targetText;

    private float speed = 2f;

    void FixedUpdate()
    {
    textComponent.transform.position = Vector3.MoveTowards (textComponent.transform.position, targetText.transform.position, Time.deltaTime * speed);
    if (textComponent.transform.position == targetText.transform.position)
    {
        GameObject.Destroy(textComponent);
    }
    
    }

}
