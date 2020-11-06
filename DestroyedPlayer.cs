using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyedPlayer : MonoBehaviour, IDestructible
{
	private PlayerAttack playerAttack;
	private GameObject timeManager;

	void Awake()
	{
		timeManager = GameObject.FindGameObjectWithTag("TimeManager");
		playerAttack = GetComponent<PlayerAttack>();
		
	}

	public void OnDestruction(GameObject destroyer)
	{
		if(playerAttack.GetBerserk())
		{
			playerAttack.baseAttack.maxDamage /= 2;
			playerAttack.baseAttack.minDamage /= 2;

			playerAttack.aoe.maxDamage /= 2;
			playerAttack.aoe.minDamage /= 2;

			playerAttack.projectile.maxDamage /= 2;
			playerAttack.projectile.minDamage /= 2;
		}
		Cursor.lockState = CursorLockMode.None;
		timeManager.GetComponent<TimeManager>().SetEndTime(Time.time);
		Invoke("Death", 0.5f);
	}

	void Death()
	{ 
		SceneManager.LoadScene("GameOverScene");
	}
}
