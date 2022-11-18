using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, -20);
    }

    // Update is called once per frame
    void Update()
    {

        this.gameObject.transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, -20);
    }
}
