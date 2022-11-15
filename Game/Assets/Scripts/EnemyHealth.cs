using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 500;

    public EnemyHealthBar healthBar;

    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        if (curHealth <= 0)
        {
            var enemies = GameObject.FindGameObjectsWithTag("Fire");

            foreach (GameObject enemy in enemies)
            {
                try
                {
                    enemy.GetComponent<FireBullets>().stopFiring(true);
                }
                catch
                {
                    enemy.GetComponent<PlayerFire>().stopFiring(true);
                }

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FriendlyBullet")
        {
            DamagePlayer(5);
        }

    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;

        healthBar.SetHealth(curHealth);
    }
}