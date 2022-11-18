using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;
    public int damage = 1;
    public int heal = 10;

    public HealthBar healthBar;

    [SerializeField] private AudioClip damageClip;
    [SerializeField] private AudioClip healClip;

    private AudioSource audioPlayer;

    void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("HeroHealth").GetComponent<HealthBar>();
        curHealth = maxHealth;
        audioPlayer = this.gameObject.GetComponent<AudioSource>();
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

            GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Stop();
            SceneManager.LoadScene("Lose Screen", LoadSceneMode.Single);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            DamagePlayer(damage);
            audioPlayer.clip = damageClip;
            audioPlayer.Play();
        }
        else if (collision.gameObject.tag == "HealthPowerUp")
        {
            if(curHealth + 10 <= maxHealth)
            {
                HealPlayer(heal);
                audioPlayer.clip = healClip;
                audioPlayer.Play();
            }           
        }
        
    }

    private void HealPlayer(int heal)
    {
        curHealth += heal;
        healthBar.SetHealth(curHealth);
    }

    public void DamagePlayer( int damage )
    {
        curHealth -= damage;

        healthBar.SetHealth( curHealth );
    }
}