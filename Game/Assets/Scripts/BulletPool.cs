using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstance;

    [SerializeField]
    private GameObject pooledBullet;
    [SerializeField]
    private GameObject friendlyPooledBullet;
    private bool notEnoughBulletsInPool = true;
    private bool notEnoughFriendlyBulletsInPool = true;

    private List<GameObject> bullets;
    private List<GameObject> friendlyBullets;

    private void Awake()
    {
        bulletPoolInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
        friendlyBullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        if(bullets.Count > 0)
        {
            for(int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }   
        }

        if (notEnoughBulletsInPool)
        {
            GameObject bul = Instantiate(pooledBullet);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }

        return null;
    }

    public GameObject GetFriendlyBullet()
    {
        if (friendlyBullets.Count > 0)
        {
            for (int i = 0; i < friendlyBullets.Count; i++)
            {
                if (!friendlyBullets[i].activeInHierarchy)
                {
                    return friendlyBullets[i];
                }
            }
        }

        if (notEnoughFriendlyBulletsInPool)
        {
            GameObject bul = Instantiate(friendlyPooledBullet);
            bul.SetActive(false);
            friendlyBullets.Add(bul);
            return bul;
        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
