using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FloatingLetterScript : MonoBehaviour
{
    // Start is called before the first frame update
    private readonly static char[] letterList = {
        'h',
        'e',
        'y',
        'i',
        'm',
        'h',
        'a',
        'v',
        'n',
        'g',
        'b',
        'd',
        't',
        'o',
        'u',
        'h',
        't',
        's',
        '.'
    };

    public float ttl;
    public float ttlVariance;
    public float fallValue;
    public float fallValueVariance;
    public Button button;

    void Start()
    {
        GetComponentInChildren<Text>().text = letterList[UnityEngine.Random.Range(0, letterList.Length - 1)].ToString();
        
        button = GetComponent<Button>();
        button.onClick.AddListener(() => TextController.Instance.ClickLetter(GetComponent<Text>().text));

        fallValue += UnityEngine.Random.Range(-fallValueVariance / 2, fallValueVariance / 2);
        ttl += UnityEngine.Random.Range(-ttlVariance / 2, ttlVariance / 2);
    }

    IEnumerator SelfDestruct() {
        yield return new WaitForSeconds(ttl);
        GameObject.Destroy(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x - fallValue, transform.position.y, transform.position.z);
    }
}
