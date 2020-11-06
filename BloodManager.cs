using System.Collections.Generic;
using UnityEngine;

public class BloodManager : MonoSingleton<BloodManager>
{
	[SerializeField] private GameObject bloodBag;
	[SerializeField] private GameObject blood;
	[SerializeField] private List<GameObject> bloodBank = new List<GameObject>();

	private void Start()
	{
		bloodBank = GenerateBlood(50);
	}

	List<GameObject> GenerateBlood(int amount)
	{
		for(int i = 0; i < amount; i++)
		{
			GameObject tempBlood = Instantiate(blood);
			tempBlood.transform.parent = bloodBag.transform;
			tempBlood.SetActive(false);
			bloodBank.Add(tempBlood);
		}
		return bloodBank;
	}

	public GameObject RequestBlood(GameObject asker)
	{
		foreach (var blood in bloodBank)
		{
			if(blood.activeInHierarchy == false)
			{
				blood.transform.position = asker.transform.position;
				blood.SetActive(true);
				return blood;
			}
		}

		GameObject tempBlood = Instantiate(blood);
		tempBlood.transform.parent = bloodBag.transform;
		bloodBank.Add(tempBlood);
		return blood;
	}
}
