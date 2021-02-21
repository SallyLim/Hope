using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pictureController : MonoBehaviour
{
    public GameObject picture1;
    public GameObject picture2;
    public GameObject picture3;
    public float opacityAcceleration;
    private bool picture1Active = false;
    private bool picture2Active = false;
    private bool picture3Active = false;
    private bool picture1TurningOn = true;
    private bool picture2TurningOn = false;
    private bool picture3TurningOn = false;
    private float opacity1 = 0;
    private float opacity2 = 0;
    private float opacity3 = 0;
    // Start is called before the first frame update
    void Start()
    {   
        picture1.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        picture2.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        picture3.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
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
        
        if (picture3TurningOn == false & picture3Active == false & picture2Active == true & picture1Active == true)
            {
                picture3TurningOn = true;
            }
        if (picture3Active == true)
            {
                SceneManager.LoadScene("afterWakingUp");
                MusicController.ins.setSong(1);
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

        if (picture3TurningOn == true)
        {
            opacity3 += opacityAcceleration;
            picture3.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, opacity3);
            if (opacity3 > 0.99f)
            {
                picture3TurningOn = false;
                picture3Active = true;
            }
        }
    }
}
