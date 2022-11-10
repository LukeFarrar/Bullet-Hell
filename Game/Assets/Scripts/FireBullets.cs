using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets: MonoBehaviour
{
    //Patterns
    [SerializeField] private int patternArrays = 1;
    [SerializeField] private int bulletAmount = 10;

    //Angle Variables
    [SerializeField] private float startAngle = 90f;
    [SerializeField] private float defaultAngle = 0f;
    [SerializeField] private float spreadBetweenArray; //Spread between Arrays
    [SerializeField] private float spreadWithinArray; //Spread between last and first bullet

    //Spinning Variables
    [SerializeField] private float spinRate = 0f;
    [SerializeField] private float spinModifier = 0f;
    [SerializeField] private bool invertSpin = true;
    [SerializeField] private float maxSpinRate = 10f;

    //Fire Rate Variables
    [SerializeField] private float timeInterval = 2f;

    //Offset Variables
    [SerializeField] private float xOffSet = 0;
    [SerializeField] private float yOffSet = 0;

    //Bullet Variables
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float ttl = 3f;
    [SerializeField] private float bulletAcceleration = 0f;
    [SerializeField] private float bulletCurve;

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

        //If Default Angle > 360 , set it to 0
        if (defaultAngle > 360 || defaultAngle < -360)
        {
            defaultAngle = 0;
        }
        defaultAngle += spinRate; //Make the pattern spin
        spinRate += spinModifier; //Apply the spin modifier

        //Invert the spin if set to 1
        if (invertSpin == true)
        {
            if (spinRate < -maxSpinRate || spinRate > maxSpinRate)
            {

                spinModifier = -spinModifier;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
