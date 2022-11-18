using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    private static AudioClip audio;
    private static GameObject character;
    private static GameObject Tower;
    private static Sprite Base;

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

    public static void setCharacter(GameObject hero)
    {
        character = hero;
    }

    public static GameObject getCharacter()
    {
        return character;
    }

    public static void setTower(GameObject towerObject)
    {
        Tower = towerObject;
    }

    public static GameObject getTower()
    {
        return Tower;
    }

    public static void setBase(Sprite baseObject)
    {
        Base = baseObject;
    }

    public static Sprite getBase()
    {
        return Base;
    }
}
