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

    [SerializeField]
    private Slider EnemyHealth;

    private float seconds = 0;
    private float minutes = 0;
    private float ticker = 0;

    private float counter = 1;
    // Start is called before the first frame update
    void Start()
    {
        counter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyHealth.value == 1)
        {
            counter++;
        }

        myText.text = "Phase: " + counter;
    }
}
