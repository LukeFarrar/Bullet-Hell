using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float offset = 90f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsTarget();
    }

    private void RotateTowardsTarget()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
    }
}
