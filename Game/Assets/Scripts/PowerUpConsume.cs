using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpConsume : MonoBehaviour
{
	private float maxSpawn = 1;
	private float size = 20f;
	[SerializeField] private GameObject HealthPrefab;
	private float counter = 0;

    private void Start()
    {
		maxSpawn = 1;
		size = 20f;
		counter = 0;
    }

    public void SpawnHealth()
    {
		var point = Random.insideUnitCircle * size;
		Debug.Log("x = " + point.x + " y=" + point.y);
		point += new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
		Debug.Log("NEW x = " + point.x + " y=" + point.y);
        Instantiate(HealthPrefab, point, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			if(collision.gameObject.GetComponent<Health>().curHealth + 10 <= 100)
            {
				Destroy(this.gameObject);
			}
			
		}

	}

	public void IncreaseHealth(float value)
    {
		maxSpawn += value;
		counter = 0;
    }
}
