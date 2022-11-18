using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    private GameObject character;
    private GameObject tower;
    private GameObject baseObject;
    // Start is called before the first frame update

    private void Awake()
    {
        character = Instantiate(GameSettings.getCharacter());
        character.transform.position = new Vector3(0.519f, -16.606f, 0);
        character.SetActive(true);

        tower = Instantiate(GameSettings.getTower());
        tower.transform.position = new Vector3(0.37f, -0.06f, 0);
        tower.SetActive(true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
