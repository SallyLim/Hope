using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textGenerate : MonoBehaviour
{
    private static string[] textList = {
        "What makes you happy?",
        "What are you most passionate about?",
        "What is your favorite place in the entire world?",
        "When have you been the most happy?"
    };

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = textList[Random.Range(0, textList.Length - 1)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
