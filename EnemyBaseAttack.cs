using UnityEngine;

public class EnemyBaseAttack : MonoBehaviour
{
    public Attack_SO baseAttack;

    private CharacterStats enemyStats;
    private GameObject enemy;

    private void Awake()
    {
        enemy = transform.root.gameObject;
        enemyStats = enemy.GetComponent<CharacterStats>();
    }
    public void OnTriggerEnter(Collider collision)
    {
        GameObject target = collision.gameObject;

        if (target.CompareTag("Player"))
        {
            var actualAttack = baseAttack.CreateAttack(enemyStats, target.GetComponent<CharacterStats>());
            var attackables = target.GetComponentsInChildren(typeof(IAttackable));

            foreach (IAttackable attackable in attackables)
            {
                attackable.OnAttack(enemy, actualAttack);
            }
        }
    }
}
