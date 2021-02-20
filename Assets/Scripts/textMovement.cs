using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textMovement : MonoBehaviour
{
    public GameObject textComponent;
    public GameObject targetText;

    private float speed = 4f;

    void OnEnable()
    {
        StartCoroutine ("textCoroutine");
    }

    void OnDisable()
    {
        StopCoroutine ("textCoroutine");
    }
    
    private IEnumerator textCoroutine()
    {
        while(true)
        {
            while(Vector3.Distance(textComponent.transform.position, targetText.transform.position) > 0.1f)
            {
                textComponent.transform.position = Vector3.MoveTowards (textComponent.transform.position, targetText.transform.position, Time.deltaTime * speed);
                yield return new WaitForSeconds (0.02f);
            }

            yield return new WaitForSeconds (0.5f);
        }
    }

}
