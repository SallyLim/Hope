using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class Saturate : MonoBehaviour
{
    public float goalSaturation;
    public float saturationIncrement;

    public PostProcessProfile post;
    public float satVal = -100;

    private ColorGrading colorGrading; 
    // Start is called before the first frame update
    void Start()
    {
        colorGrading = post.GetSetting<ColorGrading>();
        SceneManager.sceneUnloaded += (Scene scene) => colorGrading.saturation.value = -100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (satVal < goalSaturation) {
            colorGrading.saturation.value = satVal;
            satVal += saturationIncrement;
            Debug.Log(colorGrading.saturation.value);
            Debug.Log(satVal);
        }
    }
}
