using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Attack_SO attack;

    private bool playerIsAlive;
    private float range;
    private bool isMelee;

    #region Components
    private CharacterStats stats;
    private NavMeshAgent agent;
    private Transform playerPos;
    #endregion

    private void Awake()
    {
        stats = GetComponent<CharacterStats>();
        playerIsAlive = true;
        isMelee = GetComponent<EnemyMelee>();
    }

    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("PlayerCenter").transform;
        agent = GetComponent<NavMeshAgent>();
        GetComponent<NavMeshAgent>().speed = stats.GetMaxSpeed();
    }

    private void Update()
    {
        #region Movement
        if (playerIsAlive && agent.enabled)
        {
            transform.LookAt(playerPos);
            range = Vector3.SqrMagnitude(playerPos.position - transform.position);

            if (isMelee)
                agent.destination = playerPos.position;
            else
            {
                if(range > attack.range)
                    transform.position = Vector3.MoveTowards(transform.position, playerPos.position, stats.GetMaxSpeed() * Time.deltaTime);
                if(range <= attack.range)
                    transform.position = Vector3.MoveTowards(transform.position, playerPos.position, -stats.GetMaxSpeed() * Time.deltaTime);
            }
        }
        #endregion
    }
}
