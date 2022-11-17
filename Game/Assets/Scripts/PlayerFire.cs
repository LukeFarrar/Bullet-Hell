using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //Patterns
    [SerializeField] private int patternArrays = 1;
    [SerializeField] private int bulletAmount = 10;

    //Angle Variables
    [SerializeField] private float startAngle = 180f;
    [SerializeField] private float defaultAngle = 0f;
    [SerializeField] private float spreadBetweenArray; //Spread between Arrays
    [SerializeField] private float spreadWithinArray; //Spread between last and first bullet

    //Spinning Variables
    [SerializeField] private float spinRate = 0f;
    [SerializeField] private float spinModifier = 0f;
    [SerializeField] private bool invertSpin = true;
    [SerializeField] private float maxSpinRate = 10f;

    //Fire Rate Variables
    [SerializeField] private float fireRate = 2f;

    //Offset Variables
    [SerializeField] private float xOffSet = 0;
    [SerializeField] private float yOffSet = 0;

    //Bullet Variables
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float ttl = 3f;
    [SerializeField] private float bulletAcceleration = 0f;
    [SerializeField] private float bulletCurve;

    [SerializeField] private Material mat;

    private float shoot = 0;

    private bool stopFire = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (!stopFire)
        {
            Fire();
        }    
    }

    private void Fire()
    {
        //float angleStep = (endAngle - startAngle) / bulletAmount;

        float arrayAngle = (spreadWithinArray / bulletAmount); //Calculates spread between arrays
        float bulletAngle = (spreadBetweenArray / bulletAmount); //Calculates the spread between the bullets in the array

        if (shoot == 0)
        {//FireRate
            for (int i = 0; i < patternArrays; i++)
            {
                for (int j = 0; j < bulletAmount; j++)
                {
                    float angle = defaultAngle + (bulletAngle * i) + (arrayAngle * j) + startAngle;
                    float bulDirX = xOffSet + transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                    float bulDirY = yOffSet + transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                    Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                    Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                    GameObject bul = BulletPool.bulletPoolInstance.GetFriendlyBullet();
                    bul.transform.position = transform.position;
                    bul.transform.rotation = transform.rotation;
                    bul.GetComponent<Bullet>().setState(bulDir, bulletSpeed, bulletAcceleration, bulletCurve, ttl, mat);
                    bul.SetActive(true);
                }
            }
        }

        //If Default Angle > 360 , set it to 0
        if (defaultAngle > 360)
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

        shoot += 1; //fire rate control
        if (shoot >= fireRate)
        { //once shoot reaches  fire rate
            shoot = 0; //set it to 0 to shoot again
        }
    }

    public void stopFiring(bool toStop)
    {
        stopFire = toStop;
    }
}
