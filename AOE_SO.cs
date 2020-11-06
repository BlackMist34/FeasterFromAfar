using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AOE", menuName = "Combat/AOE")]
public class AOE_SO : Attack_SO
{
	public float radius;
	public float timeInScene;
	public GameObject aoePrefab;

	public void Fire(GameObject caster, Vector3 position, int layer)
	{
		GameObject aoe = Instantiate(aoePrefab, position, Quaternion.identity);
		Destroy(aoe, timeInScene);
		
		var collidedObjects = Physics.OverlapSphere(position, radius);

		foreach (var collision in collidedObjects)
		{
			var collisionGO = collision.gameObject;

			if (Physics.GetIgnoreLayerCollision(layer, collisionGO.layer))
				continue;

			var casterStats = caster.GetComponent<CharacterStats>();
			var collisionStats = collisionGO.GetComponent<CharacterStats>();

			var attack = CreateAttack(casterStats, collisionStats);

			var attackables = collisionGO.GetComponentsInChildren(typeof(IAttackable));

			foreach (IAttackable attackable in attackables)
			{
				attackable.OnAttack(caster, attack);
			}
		}
	}
}
