using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public MusicController ins;

    public List<AudioClip> songList;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (ins == null) {
            ins = this;
        } 
    }

    public void setSong(int i) {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = songList[i];
        GetComponent<AudioSource>().Play();
    }
}
