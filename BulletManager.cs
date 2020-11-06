using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoSingleton<BulletManager>
{
    #region Bullet
    [SerializeField] private GameObject clip;
	[SerializeField] private GameObject bullet;
	[SerializeField] private List<GameObject> bulletCanister = new List<GameObject>();
	#endregion

	#region Lazer
	[SerializeField] private GameObject lazerClip;
	[SerializeField] private GameObject lazer;
	[SerializeField] private List<GameObject> plasmaCanister = new List<GameObject>();
	#endregion

	#region Magic
	[SerializeField] private GameObject manaPool;
	[SerializeField] private GameObject magic;
	[SerializeField] private List<GameObject> manaSea = new List<GameObject>();
	#endregion

	#region Eldritch
	[SerializeField] private GameObject eldritchPower;
	[SerializeField] private GameObject eldritchMagic;
	[SerializeField] private List<GameObject> eldritchSea = new List<GameObject>();
	#endregion

	private void Start()
	{
		bulletCanister = GenerateBullet(10);
		plasmaCanister = GenerateLazer(10);
		manaSea = GenerateMagic(10);
		eldritchSea = GenerateEldritch(5);
	}

    #region Generate Projectiles
    List<GameObject> GenerateBullet(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			GameObject tempBullet = Instantiate(bullet);
			tempBullet.transform.parent = clip.transform;
			tempBullet.SetActive(false);
			bulletCanister.Add(tempBullet);
		}
		return bulletCanister;
	}

	List<GameObject> GenerateLazer(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			GameObject tempLazer = Instantiate(lazer);
			tempLazer.transform.parent = lazerClip.transform;
			tempLazer.SetActive(false);
			plasmaCanister.Add(tempLazer);
		}
		return plasmaCanister;
	}

	List<GameObject> GenerateMagic(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			GameObject tempMagic = Instantiate(magic);
			tempMagic.transform.parent = manaPool.transform;
			tempMagic.SetActive(false);
			manaSea.Add(tempMagic);
		}
		return manaSea;
	}

	List<GameObject> GenerateEldritch(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			GameObject tempMagic = Instantiate(eldritchMagic);
			tempMagic.transform.parent = eldritchPower.transform;
			tempMagic.SetActive(false);
			eldritchSea.Add(tempMagic);
		}
		return eldritchSea;
	}
	#endregion

	#region Request Projectile
	public GameObject RequestBullet(GameObject asker)
	{
		foreach (var bullet in bulletCanister)
		{
			if (bullet.activeInHierarchy == false)
			{
				bullet.transform.position = asker.transform.position;
				bullet.SetActive(true);
				return bullet;
			}
		}

		GameObject tempBullet = Instantiate(bullet);
		tempBullet.transform.parent = clip.transform;
		bulletCanister.Add(tempBullet);
		return bullet;
	}

	public GameObject RequestLazer(GameObject asker)
	{
		foreach (var lazer in plasmaCanister)
		{
			if (lazer.activeInHierarchy == false)
			{
				lazer.transform.position = asker.transform.position;
				lazer.SetActive(true);
				return lazer;
			}
		}

		GameObject tempLazer = Instantiate(lazer);
		tempLazer.transform.parent = lazerClip.transform;
		plasmaCanister.Add(tempLazer);
		return lazer;
	}

	public GameObject RequestMagic(GameObject asker)
	{
		foreach (var magic in manaSea)
		{
			if (magic.activeInHierarchy == false)
			{
				magic.transform.position = asker.transform.position;
				magic.SetActive(true);
				return magic;
			}
		}

		GameObject tempMagic = Instantiate(magic);
		tempMagic.transform.parent = manaPool.transform;
		manaSea.Add(tempMagic);
		return magic;
	}

	public GameObject RequestEldritch(GameObject asker)
	{
		foreach (var magic in eldritchSea)
		{
			if (magic.activeInHierarchy == false)
			{
				magic.transform.position = asker.transform.position;
				magic.SetActive(true);
				return magic;
			}
		}

		GameObject tempMagic = Instantiate(eldritchMagic);
		tempMagic.transform.parent = eldritchPower.transform;
		eldritchSea.Add(tempMagic);
		return eldritchMagic;
	}
	#endregion
}
