using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI myText;
    [SerializeField]
    private Slider Health;
    private float seconds = 0;
    private float minutes = 0;
    private float ticker = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health.value > 0 )
        {
            ticker++;
            if (ticker % 60 == 0)
            {
                seconds++;
                if (seconds % 60 == 0)
                {
                    minutes++;
                    seconds = 0;
                }
            }
            myText.text = minutes + ":" + seconds;
        }   
    }
}
