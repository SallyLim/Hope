using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class DarkenScript : MonoBehaviour
{

    public ColorGrading colorGrading;
    public PostProcessProfile post;
    public float incrementValue;
    private float evValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        colorGrading = post.GetSetting<ColorGrading>();
        SceneManager.sceneUnloaded += (Scene scene) => colorGrading.postExposure.value = evValue;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        colorGrading.postExposure.value = evValue;
        evValue -= incrementValue;
    }
}
