using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI myText;
    [SerializeField]
    private Slider Health;

    [SerializeField]
    private Slider EnemyHealth;

    private float counter = 1;
    // Start is called before the first frame update

    void Start()
    {
        myText = this.GetComponent<TextMeshProUGUI>();
        counter = 1;
        myText.text = "Phase: " + counter;
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = "Phase: " + counter;
    }

    public void increasePhase()
    {
        counter++;
    }

    public void setText(TextMeshProUGUI x)
    {
        myText = x;
    }
}
