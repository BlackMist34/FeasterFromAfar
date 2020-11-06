using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "Combat/Projectile")]
public class Projectile_SO : Attack_SO
{
	public float projectileSpeed;

	public void ShootBullet(GameObject caster, GameObject hotSpot, Vector3 target, int layer)
	{
		ProjectileController projectile = BulletManager.Instance.RequestBullet(hotSpot).GetComponent<ProjectileController>();
		projectile.Fire(caster, target, projectileSpeed, range);

		projectile.gameObject.layer = layer;

		projectile.ProjectileCollided += HandleProjectileCollided;
	}

	public void ShootLazer(GameObject caster, GameObject hotSpot, Vector3 target, int layer)
	{
		ProjectileController projectile = BulletManager.Instance.RequestLazer(hotSpot).GetComponent<ProjectileController>();
		projectile.Fire(caster, target, projectileSpeed, range);

		projectile.gameObject.layer = layer;

		projectile.ProjectileCollided += HandleProjectileCollided;
	}

	public void Cast(GameObject caster, GameObject hotSpot, Vector3 target, int layer)
	{
		ProjectileController projectile = BulletManager.Instance.RequestMagic(hotSpot).GetComponent<ProjectileController>();
		projectile.Fire(caster, target, projectileSpeed, range);

		projectile.gameObject.layer = layer;

		projectile.ProjectileCollided += HandleProjectileCollided;
	}

	public void CastEldritch(GameObject caster, GameObject hotSpot, Vector3 target, int layer)
	{
		ProjectileController projectile = BulletManager.Instance.RequestEldritch(hotSpot).GetComponent<ProjectileController>();

		projectile.gameObject.layer = layer;

		projectile.Fire(caster, target, projectileSpeed, range);

		projectile.ProjectileCollided += HandleProjectileCollided;
	}

	private void HandleProjectileCollided(GameObject caster, GameObject target)
	{
		if (caster == null || target == null)
			return;

		var casterStats = caster.GetComponent<CharacterStats>();
		var targetStats = target.GetComponent<CharacterStats>();

		var attack = CreateAttack(casterStats, targetStats);

		var attackables = target.GetComponentsInChildren(typeof(IAttackable));
		foreach (IAttackable attackable in attackables)
		{
			attackable.OnAttack(caster, attack);
		}
	}
}

