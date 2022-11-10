using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    private float movespeed = 2f;
    private bool moveRight = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 7f)
        {
            moveRight = false;
        }
        else if(transform.position.x < -7f)
        {
            moveRight = true;
        }
        
        if(moveRight)
        {
            transform.position = new Vector2(transform.position.x + movespeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - movespeed * Time.deltaTime, transform.position.y);
        }
    }
}
