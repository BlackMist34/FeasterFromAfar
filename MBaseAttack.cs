using UnityEngine;

public class MBaseAttack : MonoBehaviour
{
    public GameObject player;
    public Attack_SO baseAttack;

    private CharacterStats playerStats;
    private Animator anim;

    private void Awake()
    {
        playerStats = player.GetComponent<CharacterStats>();
        anim = player.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        GameObject target = collision.gameObject;

        if(target.CompareTag("Enemy") && anim.GetBool("isAttacking"))
        {
            var actualAttack = baseAttack.CreateAttack(playerStats, target.GetComponent<CharacterStats>());
            var attackables = target.GetComponentsInChildren(typeof(IAttackable));

            foreach (IAttackable attackable in attackables)
            {
                attackable.OnAttack(player, actualAttack);
            }
        }
    }
}
