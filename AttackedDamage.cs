using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class AttackedDamage : MonoBehaviour, IAttackable
{
	private CharacterStats stats;

	private void Awake()
	{
		stats = GetComponent<CharacterStats>();
	}

	public void OnAttack(GameObject attacker, Attack attack)
	{
		stats.TakeDamage(attack.GetDamage());

		if (stats.GetHealth() <= 0)
		{
			//Destroy Object
			var destructibles = GetComponents(typeof(IDestructible));

			foreach (IDestructible destructible in destructibles)
			{
				destructible.OnDestruction(attacker);
			}
		}
	}
}

