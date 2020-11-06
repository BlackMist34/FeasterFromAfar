using UnityEngine;

public class ParticleEffects : MonoBehaviour
{
    public void OnEnable()
    {
        Invoke("Hide", 1f);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
