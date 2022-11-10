using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets: MonoBehaviour
{
    [SerializeField]
    private int bulletAmount = 10;

    [SerializeField]
    private float startAngle = 90f, endAngle = 120f;

    [SerializeField]
    private float timeInterval = 2f;

    private Vector2 bulletMoveDirection;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, timeInterval);
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletAmount;
        float angle = startAngle;

        for(int i = 0; i< bulletAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet>().setMoveDirection(bulDir);

            angle += angleStep;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
