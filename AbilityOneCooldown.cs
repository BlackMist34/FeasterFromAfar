using UnityEngine;
using UnityEngine.UI;

public class AbilityOneCooldown : MonoBehaviour
{
    public GameObject player;

    private Animator anim;
    private CharacterStats stats;

    private void Start()
    {
        anim = GetComponent<Animator>();
        stats = player.GetComponent<CharacterStats>();
    }

    private void Update()
    {
        if (stats.GetEnergy() < 150)
            this.gameObject.GetComponent<Image>().fillAmount = 1;
        else
            this.gameObject.GetComponent<Image>().fillAmount = 0;
    }

    public void Cooldown()
    {
        anim.SetBool("AbilityOne", true);
    }
}
