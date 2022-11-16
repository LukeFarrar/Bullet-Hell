using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Test : MonoBehaviour
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

    private AudioSource audioSource;
    private float[] _samples = new float[512];
    static public float[] _frequencyBands = new float[8];

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
    }

    void Update()
    {
        GetSpectrumAudioSource();
        GetFrequencyBands();
        //6 is hi-hat
        if (_frequencyBands[6] > 4f)
        {
            Fire();
        }

        /*
        if (!stopFire)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Fire();
            }
        }
        */
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

                    GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
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

    private void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    private void GetFrequencyBands()
    {
        /**
         * 22050 /512 = 43hertz per sample
         * 20 - 60 hertz
         * 60 - 250 hertz
         * 250 - 500 hertz
         * 500 - 2000 hertz
         * 2000 - 4000 hertz
         * 4000 - 6000 hertz
         * 6000 - 20000 hertz
         * 
         * 0 - 2 = 86 hertz
         * 1 - 4 = 172 hertz - 87-258
         * 3 - 16 = 688 hertz - 259 - 602
         * 2 - 8  = 344 hertz - 603 - 1290
         * 4 - 32 = 1376 hertz - 1291 - 2666
         * 5 - 64 = 2752 hertz - 2667 - 5418
         * 6 - 128 = 5504 hertz - 5419 - 10922
         * 7 - 256 = 11008 hertz - 10923 - 21930
         * 510
         **/

        int count = 0;
        
        for(int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                average += _samples[count] * (count + 1);
                count++;
            }

            average /= count;

            _frequencyBands[i] = average * 10;
        }
    }

    public float[] getFrequencyBands()
    {
        return (_frequencyBands);
    }
}

