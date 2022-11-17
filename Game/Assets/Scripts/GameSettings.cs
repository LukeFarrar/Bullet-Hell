using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    private static AudioClip audio;

    // Start is called before the first frame update
    void Start()
    {
        if(audio != null)
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().clip = audio;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void setAudio(AudioClip music)
    { 
        audio = music;
    }

    public static AudioClip getAudio()
    {
        return audio;
    }
}
