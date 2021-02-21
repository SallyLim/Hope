using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour
{
    const int active = 219;
    const float timeToFade = 0.1f;

    public AudioClip decClip;
    public AudioClip incClip;

    [SerializeField] TMP_Text text;
    public static TextController Instance;
    public int curIndex = 0;
    public int fadeIndex = -1;
    public float timer = timeToFade;
    public int curFade = active;

    const int inactive = 20;

    private bool initialized = false;

    // Start is called before the first frame update
    public void Awake()
    {
        if (TextController.Instance == null) {
            TextController.Instance = this;
        }
    }

    public void Update() {
        if (Time.timeSinceLevelLoad > 0.1 && !initialized) {
            for (int i = 0; i < text.textInfo.characterInfo.Length; i++) {
                SetColor(i, new Color32(inactive, inactive, inactive, 255));
            }
            initialized = true;
        }

        timer -= Time.deltaTime;
        if (timer < 0) {
            timer = timeToFade;

            if (fadeIndex >= 0) {
                Debug.Log(curFade);
                curFade--;
                if (curFade == inactive) {
                    Dec();
                    curFade = active;
                } else {
                    SetColor(fadeIndex, new Color32((byte) curFade,(byte) curFade,(byte) curFade,255));
                }
            }
        }
    }

    public void ClickLetter(string letter) {
        if (letter[0] == text.textInfo.characterInfo[curIndex].character) {
            SetColor(curIndex, new Color32(active, active, active, 255));
            Inc();
        }
        else {
            Dec();
        }
    }

    public void Inc() {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = incClip;
        GetComponent<AudioSource>().Play();


        SetColor(fadeIndex, new Color32(active, active, active, 255));
        curFade = active;
        fadeIndex = curIndex;
        curIndex++;
        if (text.textInfo.characterInfo[curIndex].character == ' ') {
            curIndex++;
        } else if (text.textInfo.characterInfo[curIndex].character == '.')
        {
            SceneManager.LoadScene("FinalCutscene");
        }
    }

    public void Dec() {

        
        SetColor(fadeIndex, new Color32(inactive, inactive, inactive, 255));
        if (fadeIndex > -1) {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = decClip;
            GetComponent<AudioSource>().Play();

            
            curIndex = fadeIndex;
            fadeIndex--;
            if (fadeIndex > -1 && text.textInfo.characterInfo[fadeIndex].character == ' ') {
                fadeIndex--;
            }
        }
    }

    public void SetColor(int index, Color32 color) {
        if (index < 0) {
            return;
        }

        int meshIndex = text.textInfo.characterInfo[index].materialReferenceIndex;
        int vertexIndex = text.textInfo.characterInfo[index].vertexIndex;

        Color32[] vertexColors = text.textInfo.meshInfo[meshIndex].colors32;

        vertexColors[vertexIndex + 0] = color;
        vertexColors[vertexIndex + 1] = color;
        vertexColors[vertexIndex + 2] = color;
        vertexColors[vertexIndex + 3] = color;

        text.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
    }
}
