using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    const int b = 53;
    const float timeToFade = 0.01f;

    [SerializeField] TMP_Text text;
    public static TextController Instance;
    public int curIndex = 0;
    public int fadeIndex = -1;
    public float timer = timeToFade;
    public int curFade = b;

    // Start is called before the first frame update
    void Awake()
    {
        if (TextController.Instance == null) {
            TextController.Instance = this;
        }
    }

    void Update() {
        timer -= Time.deltaTime;
        if (timer < 0) {
            timer = timeToFade;

            if (fadeIndex >= 0) {
                Debug.Log(curFade);
                curFade++;
                if (curFade == 255) {
                    dec();
                    curFade = b;
                } else {
                    SetColor(fadeIndex, new Color32((byte) curFade,(byte) curFade,(byte) curFade,255));
                }
            }
        }
    }

    public void ClickLetter(string letter) {
        if (letter[0] == text.textInfo.characterInfo[curIndex].character) {
            SetColor(curIndex, new Color32(b, b, b, 255));
            inc();
        }

        
    }

    public void inc() {
        SetColor(fadeIndex, new Color32(b, b, b, 255));
        curFade = b;
        fadeIndex = curIndex;
        curIndex++;
        if (text.textInfo.characterInfo[curIndex].character == ' ') {
            curIndex++;
        }
        Debug.Log("Inc");
    }

    public void dec() {
        if (fadeIndex > -2) {
            curIndex = fadeIndex;
            fadeIndex--;
            if (fadeIndex > -1 && text.textInfo.characterInfo[fadeIndex].character == ' ') {
                fadeIndex--;
            }
        }

        Debug.Log("DEc");
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
