using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        MusicController.ins.setSong(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
