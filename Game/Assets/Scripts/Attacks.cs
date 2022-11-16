using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    private FireBullets[] shooters = new FireBullets[8];
    // Start is called before the first frame update
    public static bool Phase2 = false, Phase3 = false, Phase4 = false, Phase5 = false, Phase6 = false, Phase7 = false, Phase8 = false;
    void Start()
    {
        var fires = GameObject.FindGameObjectsWithTag("Fire");
        var i = 0;
        foreach (GameObject value in fires)
        {
            foreach(FireBullets comp in value.GetComponents<FireBullets>())
            {
                shooters[i] = comp;
                i++;
            }            
        }
    }

    // Update is called once per frame
    void Update()
    {
        var freqBands = TestMusic._frequencyBands;
        //Main Beat Keep as is, Works well.
        if(freqBands[1] >= 1f)
        {
            shooters[1].Fire();
        }
        //Kickdrum
        if (freqBands[0] > 2f && Phase2)
        {
            shooters[0].Fire();
        }
        /*
        if (freqBands[2] > 3f && Phase3)
        {
            shooters[2].Fire();
        }
        if (freqBands[3] > 1f && Phase4)
        {
            shooters[3].Fire();
        }
        if (freqBands[4] > 1.5f && Phase5)
        {
            shooters[4].Fire();
        }
        if (freqBands[5] > 1.5f && Phase6)
        {
            shooters[5].Fire();
        }
        //Hi-hat
        if (freqBands[6] > 1.5f && Phase7)
        {
            shooters[6].Fire();
        }
        if (freqBands[7] > 1.5f && Phase8)
        {
            shooters[7].Fire();
        }
        */
    }
}
