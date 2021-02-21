using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Lighten : MonoBehaviour
{

    public ColorGrading colorGrading;
    public PostProcessProfile post;
    public float evValue = 2;

    // Start is called before the first frame update
    void OnEnable()
    {
        post.GetSetting<ColorGrading>().postExposure.value = evValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
