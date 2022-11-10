using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets: MonoBehaviour
{
    [SerializeField]
    private int patternArrays = 1;

    [SerializeField]
    private int bulletAmount = 10;

    [SerializeField]
    private float startAngle = 90f, defaultAngle = 0f;

    [SerializeField]
    private float bulletSpeed = 5f;

    [SerializeField]
    private float spreadBetweenArray; //Spread between Arrays

    [SerializeField]
    private float spreadWithinArray; //Spread between last and first bullet

    [SerializeField]
    private float timeInterval = 2f;

    [SerializeField]
    private float xOffSet = 0, yOffSet = 0;

    [SerializeField]
    private float ttl = 3f;

    [SerializeField]
    private float bulletAcceleration = 0f;

    [SerializeField]
    private float bulletCurve;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, timeInterval);
    }

    private void Fire()
    {
        //float angleStep = (endAngle - startAngle) / bulletAmount;

        float arrayAngle = (spreadWithinArray / bulletAmount); //Calculates spread between arrays
        float bulletAngle = (spreadBetweenArray / bulletAmount); //Calculates the spread between the bullets in the array

        for (int i = 0; i < patternArrays; i++)
        { 
            for (int j = 0; j < bulletAmount; j++)
            {
                float angle = defaultAngle + (bulletAngle * i) + (arrayAngle * j) + startAngle;
                float bulDirX = xOffSet + transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                float bulDirY = yOffSet + transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.GetComponent<Bullet>().setState(bulDir, bulletSpeed, bulletAcceleration, bulletCurve, ttl);
                bul.SetActive(true);       
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
