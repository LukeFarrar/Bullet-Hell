using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 moveDir;
    private float moveSpeed;
    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }

    public void setMoveDirection(Vector2 dir)
    {
        moveDir = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
