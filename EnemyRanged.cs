using System.Collections;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    public Projectile_SO weapon;

    private RaycastHit hit;
    private Ray ray;
    private float rayDistance;

    private float timeOfLastAttack;

    private void Start()
    {
        rayDistance = weapon.range;
        timeOfLastAttack = float.MinValue;
    }

    private void Update()
    {
        int layerMask = 1 << 8;
        float timeSinceLastAttack = Time.time - timeOfLastAttack;
        
        ray = new Ray(transform.position, transform.forward);

        if (!(timeSinceLastAttack < weapon.cooldown))
        {
            if (Physics.Raycast(ray, out hit, layerMask) && hit.distance < rayDistance && hit.collider.CompareTag("Player"))
            {
                StartCoroutine("BaseAttack");
            }
        }
    }

    IEnumerator BaseAttack()
    {
        if(weapon.minDamage < 15)
            weapon.ShootBullet(transform.parent.parent.gameObject, gameObject, hit.collider.transform.position, LayerMask.NameToLayer("EnemyAttacks"));
        else if (weapon.minDamage < 25 && weapon.minDamage > 15)
            weapon.ShootLazer(transform.parent.parent.gameObject, gameObject, hit.collider.transform.position, LayerMask.NameToLayer("EnemyAttacks"));
        else if (weapon.minDamage > 25)
            weapon.Cast(transform.parent.parent.parent.gameObject, gameObject, hit.collider.transform.position, LayerMask.NameToLayer("EnemyAttacks"));
        timeOfLastAttack = Time.time;
        yield return new WaitForSeconds(1f);
    }
}
