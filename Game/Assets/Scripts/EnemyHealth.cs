using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;
    public int damage = 1;
    private int counter = 1;

    public EnemyHealthBar healthBar;
    private GameObject bar;
    private GameObject underBar;
    private AudioClip hitClip;
    private AudioSource audioPlayer;

    void Start()
    {
        audioPlayer = this.gameObject.GetComponent<AudioSource>();
        counter = 1;
        curHealth = maxHealth;
        damage = 2;

        healthBar = GameObject.FindGameObjectWithTag("EnemyBar").GetComponent<EnemyHealthBar>();
        bar = GameObject.FindGameObjectWithTag("EnemyBarImage");
        underBar = GameObject.FindGameObjectWithTag("EnemyUnderBar");

        bar.GetComponent<Image>().color = new Color(0.3f, 0.2f, 0.6f, 1f);
        underBar.GetComponent<Image>().color = new Color(0f, 0f, 1f, 1f);
    }

    void Update()
    {
        if(curHealth <= 1)
        {
            counter++;
            if(counter <= 8)
            {
                curHealth = maxHealth;
                healthBar.SetHealth(curHealth);
            }
        }
        if (counter == 2)
        {
            bar.GetComponent<Image>().color = new Color(0f, 0f, 1f, 1f);
            underBar.SetActive(false);
            underBar.GetComponent<Image>().color = new Color(0f, 1f, 0f, 1f);
            underBar.SetActive(true);
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Attacks>().Phase2 = true;
        }
        if (counter == 3)
        {
            bar.GetComponent<Image>().color = new Color(0f, 1f, 0f, 1f);
            underBar.GetComponent<Image>().color = new Color(1f, 1f, 0f, 1f);
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Attacks>().Phase3 = true;
        }
        if (counter == 4)
        {
            bar.GetComponent<Image>().color = new Color(1f, 1f, 0f, 1f);
            underBar.GetComponent<Image>().color = new Color(0f, 1f, 1f, 1f);
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Attacks>().Phase4 = true;
        }
        if (counter == 5)
        {
            bar.GetComponent<Image>().color = new Color(0f, 1f, 1f, 1f);
            underBar.GetComponent<Image>().color = new Color(1f, 0f, 1f, 1f);
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Attacks>().Phase5 = true;
        }
        if (counter == 6)
        {
            bar.GetComponent<Image>().color = new Color(1f, 0f, 1f, 1f);
            underBar.GetComponent<Image>().color = new Color(0.3f, 1f, 0.5f, 1f);
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Attacks>().Phase6 = true;
        }
        if (counter == 7)
        {
            bar.GetComponent<Image>().color = new Color(0.3f, 1f, 0.5f, 1f);
            underBar.GetComponent<Image>().color = new Color(1f, 0f, 0f, 1f);
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Attacks>().Phase7 = true;
        }
        if (counter == 8)
        {
            bar.GetComponent<Image>().color = new Color(1f, 0f, 0f, 1f);
            underBar.SetActive(false);
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Attacks>().Phase8 = true;
        }
            
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
            SceneManager.LoadScene("Win Screen", LoadSceneMode.Single);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FriendlyBullet")
        {
            audioPlayer.clip = hitClip;
            audioPlayer.Play();
            DamagePlayer(damage);
        }

    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;

        healthBar.SetHealth(curHealth);
    }
}