using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Combat/Attack")]
public class Attack_SO : ScriptableObject
{
    public int minDamage;
    public int maxDamage;
    public int cost;
    public float cooldown;
    public float range;
    public float critChance;
    public float critMultiplier;

    public Attack CreateAttack(CharacterStats attacker, CharacterStats defender)
    {
        float damage = attacker.GetDamage() + Random.Range(minDamage, maxDamage);

        bool isCritical = Random.value < critChance;
        if (isCritical)
            damage *= critMultiplier;

        if (defender != null)
            damage -= defender.GetDefense();

        return new Attack(damage, isCritical);
    }
}
