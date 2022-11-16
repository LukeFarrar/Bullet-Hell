using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Slider underBar;
    public EnemyHealth EnemyHealth;

    private void Start()
    {
        EnemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = EnemyHealth.maxHealth;
        healthBar.value = EnemyHealth.maxHealth;
        underBar.maxValue = EnemyHealth.maxHealth;
        underBar.value = EnemyHealth.maxHealth;
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}