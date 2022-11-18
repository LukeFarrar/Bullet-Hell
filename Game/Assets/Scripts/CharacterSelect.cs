using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField] private Toggle Character;
    [SerializeField] private GameObject CharacterObject;
    // Start is called before the first frame update
    void Start()
    {
        Character.onValueChanged.AddListener(SelectCharacter);
        if(Character.isOn)
        {
            SelectCharacter(false);
        }
    }

    private void SelectCharacter(bool arg0)
    {
        if(Character.isOn)
        {
            GameSettings.setCharacter(CharacterObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
