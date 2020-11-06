using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedForceField : MonoBehaviour, IDestructible
{
    private GameObject parent;

    private void Awake()
    {
        parent = transform.root.gameObject;

        parent.GetComponent<AttackedDamage>().enabled = false;
    }

    public void OnDestruction(GameObject destroyer)
    {
        parent.GetComponent<AttackedDamage>().enabled = true;

        gameObject.SetActive(false);
    }
}
