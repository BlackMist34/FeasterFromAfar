using UnityEngine;
using System;

public class ProjectileController : MonoBehaviour
{
	private GameObject caster;
	private float speed;
	private float range;
	private Vector3 travelDirection;

	private float distanceTraveled;

	public event Action<GameObject, GameObject> ProjectileCollided;

	public void Fire(GameObject caster, Vector3 target, float speed, float range)
	{
		this.caster = caster;
		this.speed = speed;
		this.range = range;

		//calculate travel distance
		travelDirection = target - transform.position;
		travelDirection.y = 0f;
		travelDirection.Normalize();

		//initialize distance traveled
		distanceTraveled = 0;
	}

	public void Update()
	{
		//move this projectile through space
		float distanceToTravel = speed * Time.deltaTime;

		transform.Translate(travelDirection * distanceToTravel);

		//check to see if we went beyond range
		distanceTraveled += distanceToTravel;
		if (distanceTraveled > range)
		{
			gameObject.SetActive(false);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			if (ProjectileCollided != null)
				ProjectileCollided(caster, other.gameObject);

			gameObject.SetActive(false);
		}

		if(other.gameObject.CompareTag("Player"))
		{
			if (ProjectileCollided != null)
				ProjectileCollided(caster, other.gameObject);

			gameObject.SetActive(false);
		}
	}

	public GameObject GetCaster()
	{
		return caster;
	}
}

