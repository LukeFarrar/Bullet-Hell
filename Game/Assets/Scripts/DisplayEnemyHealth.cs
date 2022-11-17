using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayEnemyHealth : MonoBehaviour
{
    private TextMeshProUGUI myText;
    // Start is called before the first frame update
    void Start()
    {
        myText = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPhase(int phase)
    {
        if (phase == 1)
        {
            myText.text = ".......";
        }
        else if (phase == 2)
        {
            myText.text = "......";
        }
        else if (phase == 3)
        {
            myText.text = ".....";
        }
        else if (phase == 4)
        {
            myText.text = "....";
        }
        else if (phase == 5)
        {
            myText.text = "...";
        }
        else if (phase == 6)
        {
            myText.text = "..";
        }
        else if (phase == 7)
        {
            myText.text = ".";
        }
        else if (phase == 8)
        {
            myText.text = "";
        }
    }
}
