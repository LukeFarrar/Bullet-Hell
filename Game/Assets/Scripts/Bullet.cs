using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 moveDir;
    private float moveSpeed = 0f;
    private float ttl = 0f;
    private float acceleration = 0f;
    private float curve = 0f;
    private void OnEnable()
    {
        Invoke("Destroy", ttl);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.moveDir = this.moveDir + new Vector2(curve, curve);
        moveSpeed = moveSpeed + acceleration;
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }

    public void setMoveDirection(Vector2 dir)
    {
        moveDir = dir;
    }

    public void setSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public void setTTL(float ttl)
    {
        this.ttl = ttl;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void setState(Vector2 dir, float speed, float acceleration, float curve, float ttl)
    {
        moveDir = dir;
        moveSpeed = speed;
        this.ttl = ttl;
        this.acceleration = acceleration;
        this.curve = curve;
    }
}
