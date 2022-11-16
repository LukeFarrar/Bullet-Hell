using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 500;
    public int damage = 1;

    public EnemyHealthBar healthBar;

    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        if (curHealth < (maxHealth - maxHealth / 8))
            Attacks.Phase2 = true;
        if (curHealth < (maxHealth - 2*(maxHealth / 8)))
            Attacks.Phase3 = true;
        if (curHealth < (maxHealth - 3 * (maxHealth / 8)))
            Attacks.Phase4 = true;
        if (curHealth < (maxHealth - 4 * (maxHealth / 8)))
            Attacks.Phase5 = true;
        if (curHealth < (maxHealth - 5 * (maxHealth / 8)))
            Attacks.Phase6 = true;
        if (curHealth < (maxHealth - 6 * (maxHealth / 8)))
            Attacks.Phase7 = true;
        if (curHealth < (maxHealth - 7 * (maxHealth / 8)))
            Attacks.Phase8 = true;
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
            GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Stop();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FriendlyBullet")
        {
            DamagePlayer(damage);
        }

    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;

        healthBar.SetHealth(curHealth);
    }
}