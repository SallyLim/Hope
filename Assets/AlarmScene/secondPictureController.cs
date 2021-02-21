using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class secondPictureController : MonoBehaviour
{
    public GameObject picture1;
    public GameObject picture2;
    public float opacityAcceleration;
    private bool picture1Active = false;
    private bool picture2Active = false;
    private bool picture1TurningOn = false;
    private bool picture2TurningOn = false;
    private float opacity1 = 0;
    private float opacity2 = 0;
    // Start is called before the first frame update
    void Start()
    {   
        picture1.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        picture2.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) | Input.touchCount > 0) 
        {
            if(picture1TurningOn == false & picture1Active == false)
            {
                picture1TurningOn = true;
            }
           
        if (picture2TurningOn == false & picture2Active == false & picture1Active == true)
            {
                picture2TurningOn = true;
            }
        if (picture2Active == true)
            {
                SceneManager.LoadScene("ReachOutScene");
            }
        }
        if (picture1TurningOn == true)
        {
            opacity1 += opacityAcceleration;
            picture1.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, opacity1);
            if (opacity1 > 0.99f)
            {
                picture1TurningOn = false;
                picture1Active = true;
            }
        }

        if (picture2TurningOn == true)
        {
            opacity2 += opacityAcceleration;
            picture2.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, opacity2);
            if (opacity2 > 0.99f)
            {
                picture2TurningOn = false;
                picture2Active = true;
            }
        }
    }
}
