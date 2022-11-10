using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
    
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
