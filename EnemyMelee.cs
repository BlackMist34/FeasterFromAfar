using System.Collections;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public Attack_SO attack;

    private RaycastHit hit;
    private Ray ray;
    private float rayDistance;

    private Animator anim;

    private void Start()
    {
        rayDistance = attack.range;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit) && hit.distance <= rayDistance && hit.collider.CompareTag("Player"))
        {
            StartCoroutine("BaseAttack");
        }
    }

    IEnumerator BaseAttack()
    {
        anim.SetBool("isAttacking", true);

        yield return new WaitForSeconds(.25f);

        anim.SetBool("isAttacking", false);
    }
}
