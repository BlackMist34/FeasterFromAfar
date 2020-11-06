using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSoldierSingleton<T> : MonoBehaviour where T : MonoSoldierSingleton<T>
{
    #region MonoSingleton Part
    private static T instance;
	public static T Instance
	{
		get
		{
			if (instance == null)
				Debug.LogError(typeof(T).ToString() + " is NULL");

			return instance;
		}
	}

	private void Awake()
	{
		instance = this as T;
	}
	#endregion

	#region Soldier Summoning Part
	#region Lv1
	[SerializeField] private GameObject soldierLv1Holder;
	[SerializeField] private GameObject soldierLv1;
	[SerializeField] private List<GameObject> Lv1SoldierBarracks = new List<GameObject>();
	#endregion

	#region Lv2
	[SerializeField] private GameObject soldierLv2Holder;
	[SerializeField] private GameObject soldierLv2;
	[SerializeField] private List<GameObject> Lv2SoldierBarracks = new List<GameObject>();
	#endregion

	#region Lv3
	[SerializeField] private GameObject soldierLv3Holder;
	[SerializeField] private GameObject soldierLv3;
	[SerializeField] private List<GameObject> Lv3SoldierBarracks = new List<GameObject>();
	#endregion

	#region Lv4
	[SerializeField] private GameObject soldierLv4Holder;
	[SerializeField] private GameObject soldierLv4;
	[SerializeField] private List<GameObject> Lv4SoldierBarracks = new List<GameObject>();
	#endregion

	#region Lv5
	[SerializeField] private GameObject soldierLv5Holder;
	[SerializeField] private GameObject soldierLv5;
	[SerializeField] public List<GameObject> Lv5SoldierBarracks = new List<GameObject>();
	#endregion

	private void Start()
	{
		Lv5SoldierBarracks = GenerateLv5Soldier(25);
		Lv1SoldierBarracks = GenerateLv1Soldier(6);
		Lv2SoldierBarracks = GenerateLv2Soldier(6);
		Lv3SoldierBarracks = GenerateLv3Soldier(6);
		Lv4SoldierBarracks = GenerateLv4Soldier(6);
	}

	#region List Creation
	List<GameObject> GenerateLv1Soldier(int amountOfSoldiers)
	{
		for (int i = 0; i < amountOfSoldiers; i++)
		{
			GameObject soldier = Instantiate(soldierLv1);
			soldier.transform.parent = soldierLv1Holder.transform;
			soldier.SetActive(false);
			Lv1SoldierBarracks.Add(soldier);
		}
		return Lv1SoldierBarracks;
	}
	List<GameObject> GenerateLv2Soldier(int amountOfSoldiers)
	{
		for (int i = 0; i < amountOfSoldiers; i++)
		{
			GameObject soldier = Instantiate(soldierLv2);
			soldier.transform.parent = soldierLv2Holder.transform;
			soldier.SetActive(false);
			Lv2SoldierBarracks.Add(soldier);
		}
		return Lv2SoldierBarracks;
	}
	List<GameObject> GenerateLv3Soldier(int amountOfSoldiers)
	{
		for (int i = 0; i < amountOfSoldiers; i++)
		{
			GameObject soldier = Instantiate(soldierLv3);
			soldier.transform.parent = soldierLv3Holder.transform;
			soldier.SetActive(false);
			Lv3SoldierBarracks.Add(soldier);
		}
		return Lv3SoldierBarracks;
	}
	List<GameObject> GenerateLv4Soldier(int amountOfSoldiers)
	{
		for (int i = 0; i < amountOfSoldiers; i++)
		{
			GameObject soldier = Instantiate(soldierLv4);
			soldier.transform.parent = soldierLv4Holder.transform;
			soldier.SetActive(false);
			Lv4SoldierBarracks.Add(soldier);
		}
		return Lv4SoldierBarracks;
	}
	List<GameObject> GenerateLv5Soldier(int amountOfSoldiers)
	{
		for (int i = 0; i < amountOfSoldiers; i++)
		{
			GameObject soldier = Instantiate(soldierLv5);
			soldier.transform.parent = soldierLv5Holder.transform;
			soldier.SetActive(false);
			Lv5SoldierBarracks.Add(soldier);
		}
		return Lv5SoldierBarracks;
	}
	#endregion

	#region Request Soldiers
	public GameObject RequestLv1Soldier(GameObject asker)
	{
		foreach (var soldierLv1 in Lv1SoldierBarracks)
		{
			if (soldierLv1.activeInHierarchy == false)
			{
				soldierLv1.transform.position = asker.transform.position;
				soldierLv1.SetActive(true);
				return soldierLv1;
			}
		}

		return null;
	}
	public GameObject RequestLv2Soldier(GameObject asker)
	{
		foreach (var soldierLv2 in Lv2SoldierBarracks)
		{
			if (soldierLv2.activeInHierarchy == false)
			{
				soldierLv2.transform.position = asker.transform.position;
				soldierLv2.SetActive(true);
				return soldierLv2;
			}
		}

		return null;
	}
	public GameObject RequestLv3Soldier(GameObject asker)
	{
		foreach (var soldierLv3 in Lv3SoldierBarracks)
		{
			if (soldierLv3.activeInHierarchy == false)
			{
				soldierLv3.transform.position = asker.transform.position;
				soldierLv3.SetActive(true);
				return soldierLv3;
			}
		}

		return null;
	}
	public GameObject RequestLv4Soldier(GameObject asker)
	{
		foreach (var soldierLv4 in Lv4SoldierBarracks)
		{
			if (soldierLv4.activeInHierarchy == false)
			{
				soldierLv4.transform.position = asker.transform.position;
				soldierLv4.SetActive(true);
				return soldierLv4;
			}
		}

		return null;
	}
	public GameObject RequestLv5Soldier(GameObject asker)
	{
		foreach (var soldierLv5 in Lv5SoldierBarracks)
		{
			if (soldierLv5.activeInHierarchy == false)
			{
				soldierLv5.transform.position = asker.transform.position;
				soldierLv5.SetActive(true);
				return soldierLv5;
			}
		}

		GameObject soldier = Instantiate(soldierLv4);
		soldier.transform.position = asker.transform.position;
		Lv4SoldierBarracks.Add(soldier);
		return soldier;
	}
	#endregion
	#endregion
}
