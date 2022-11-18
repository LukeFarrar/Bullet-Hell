using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseMusic : MonoBehaviour
{
    [SerializeField] private AudioClip audio;
    [SerializeField] private GameObject tower;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(changeMusic);
    }

    private void changeMusic()
    {
        GameSettings.setAudio(audio);
        GameSettings.setTower(tower);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
