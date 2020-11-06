using UnityEngine;
using UnityEngine.AI;

public class DestroyedEnemy : MonoBehaviour, IDestructible
{
    public GameObject blood;

    void IDestructible.OnDestruction(GameObject destroyer)
    {
        BloodManager.Instance.RequestBlood(gameObject);
        Invoke("Hide", 0f);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
    }
}
