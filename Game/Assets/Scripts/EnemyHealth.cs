using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;
    public int damage = 1;
    private int counter = 1;

    public EnemyHealthBar healthBar;
    [SerializeField] private GameObject bar;
    [SerializeField] private GameObject underBar;

    void Start()
    {
        counter = 1;
        curHealth = maxHealth;
        damage = 1;
        bar.GetComponent<Image>().color = new Color(0.3f, 0.2f, 0.6f, 1f);
        underBar.GetComponent<Image>().color = new Color(0f, 0f, 1f, 1f);
    }

    void Update()
    {
        if(curHealth <= 1)
        {
            counter++;
            if(counter < 8)
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
            Attacks.Phase2 = true;
        }
        if (counter == 3)
        {
            bar.GetComponent<Image>().color = new Color(0f, 1f, 0f, 1f);
            underBar.GetComponent<Image>().color = new Color(1f, 1f, 0f, 1f);
            Attacks.Phase3 = true;
        }
        if (counter == 4)
        {
            bar.GetComponent<Image>().color = new Color(1f, 1f, 0f, 1f);
            underBar.GetComponent<Image>().color = new Color(0f, 1f, 1f, 1f);
            Attacks.Phase4 = true;
        }
        if (counter == 5)
        {
            bar.GetComponent<Image>().color = new Color(0f, 1f, 1f, 1f);
            underBar.GetComponent<Image>().color = new Color(1f, 0f, 1f, 1f);
            Attacks.Phase5 = true;
        }
        if (counter == 6)
        {
            bar.GetComponent<Image>().color = new Color(1f, 0f, 1f, 1f);
            underBar.GetComponent<Image>().color = new Color(0.3f, 1f, 0.5f, 1f);
            Attacks.Phase6 = true;
        }
        if (counter == 7)
        {
            bar.GetComponent<Image>().color = new Color(0.3f, 1f, 0.5f, 1f);
            underBar.GetComponent<Image>().color = new Color(1f, 0f, 0f, 1f);
            Attacks.Phase7 = true;
        }
        if (counter == 8)
        {
            bar.GetComponent<Image>().color = new Color(1f, 0f, 0f, 1f);
            underBar.SetActive(false);
            Attacks.Phase8 = true;
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