using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        StartCoroutine("TurnOnNavMesh");
    }

    IEnumerator TurnOnNavMesh()
    {
        yield return new WaitForSeconds(0.1f);

        agent.enabled = true;
    }
}
