using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    private FireBullets[] shooters = new FireBullets[8];
    // Start is called before the first frame update
    public bool Phase2 = false, Phase3 = false, Phase4 = false, Phase5 = false, Phase6 = false, Phase7 = false, Phase8 = false;
    private bool heal1 = false;
    public bool PhaseIncrease2 = false, PhaseIncrease3 = false, PhaseIncrease4 = false, PhaseIncrease5 = false, PhaseIncrease6 = false, PhaseIncrease7 = false, PhaseIncrease8 = false;
    public GameObject HealthPrefab;
    private PowerUpConsume HealthPowerUp;
    private float numHealth = 0;
    private int counter = 0;
    private DisplayEnemyHealth HealthBar;
    void Start()
    {
        HealthPowerUp = HealthPrefab.GetComponent<PowerUpConsume>();
        HealthBar = GameObject.FindGameObjectWithTag("EnemyHealth").GetComponent<DisplayEnemyHealth>();
        counter = 0;
        numHealth = 0;

        heal1 = false;
  
        Phase2 = false;
        Phase3 = false;
        Phase4 = false;
        Phase5 = false;
        Phase6 = false;
        Phase7 = false;
        Phase8 = false;
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
        if (heal1 == false)
        {
            HealthBar.setPhase(1);
            numHealth += 3;
            counter = 0;
            heal1 = true;
            for (int a = counter; a < numHealth; a++)
            {
                HealthPowerUp.SpawnHealth();
                counter++;
            }
        }
        if (freqBands[1] >= 1f)
        {
            shooters[1].Fire();
        }
        if(Phase2 && !PhaseIncrease2)
        {
            HealthBar.setPhase(2);
            PhaseIncrease2 = true;
            GameObject.FindGameObjectWithTag("Text").GetComponent<Timer>().increasePhase();
            numHealth += 2;
            counter = 0;
            for (int a = counter; a < numHealth; a++)
            {
                HealthPowerUp.SpawnHealth();
                counter++;
            }
        }
        //Kickdrum
        if (freqBands[0] > 2f && Phase2)
        {
            shooters[0].Fire();
        }
        if (Phase3 && !PhaseIncrease3)
        {
            HealthBar.setPhase(3);
            PhaseIncrease3 = true;
            GameObject.FindGameObjectWithTag("Text").GetComponent<Timer>().increasePhase();
            numHealth += 2;
            counter = 0;
            for (int a = counter; a < numHealth; a++)
            {
                HealthPowerUp.SpawnHealth();
                counter++;
            }
        }
        if (freqBands[2] > 3f && Phase3)
        {
            shooters[2].Fire();
        }
        if (Phase4 && !PhaseIncrease4)
        {
            HealthBar.setPhase(4);
            PhaseIncrease4 = true;
            GameObject.FindGameObjectWithTag("Text").GetComponent<Timer>().increasePhase();
            numHealth += 2;
            counter = 0;
            for (int a = counter; a < numHealth; a++)
            {
                HealthPowerUp.SpawnHealth();
                counter++;
            }
        }
        if (freqBands[3] > 3f && Phase4)
        {
            shooters[3].Fire();
        }
        if (Phase5 && !PhaseIncrease5)
        {
            HealthBar.setPhase(5);
            PhaseIncrease5 = true;
            GameObject.FindGameObjectWithTag("Text").GetComponent<Timer>().increasePhase();
            numHealth += 2;
            counter = 0;
            for (int a = counter; a < numHealth; a++)
            {
                HealthPowerUp.SpawnHealth();
                counter++;
            }
        }
        if (freqBands[4] > 1.5f && Phase5)
        {
            shooters[4].Fire();
        }
        if (Phase6 && !PhaseIncrease6)
        {
            HealthBar.setPhase(6);
            PhaseIncrease6 = true;
            GameObject.FindGameObjectWithTag("Text").GetComponent<Timer>().increasePhase();
            numHealth += 2;
            counter = 0;
            for (int a = counter; a < numHealth; a++)
            {
                HealthPowerUp.SpawnHealth();
                counter++;
            }
        }
        if (freqBands[5] > 1.5f && Phase6)
        {
            shooters[5].Fire();
        }
        //Hi-hat
        if (Phase7 && !PhaseIncrease7)
        {
            HealthBar.setPhase(7);
            PhaseIncrease7 = true;
            GameObject.FindGameObjectWithTag("Text").GetComponent<Timer>().increasePhase();
            numHealth += 2;
            counter = 0;
            for (int a = counter; a < numHealth; a++)
            {
                HealthPowerUp.SpawnHealth();
                counter++;
            }
        }
        if (freqBands[6] > 3f && Phase7)
        {
            shooters[6].Fire();
        }
        if (Phase8 && !PhaseIncrease8)
        {
            HealthBar.setPhase(8);
            PhaseIncrease8 = true;
            GameObject.FindGameObjectWithTag("Text").GetComponent<Timer>().increasePhase();
            numHealth += 2;
            counter = 0;
            for (int a = counter; a < numHealth; a++)
            {
                HealthPowerUp.SpawnHealth();
                counter++;
            }
        }
        if (freqBands[7] > 1.5f && Phase8)
        {
            shooters[7].Fire();
        }
        
    }
}
