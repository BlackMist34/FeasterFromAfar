using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public GameObject player;

    private Image image;
    private CharacterStats playerStats;

    private void Start()
    {
        image = GetComponent<Image>();
        playerStats = player.GetComponent<CharacterStats>();
    }

    private void Update()
    {
        image.fillAmount = playerStats.characterDefinition.currentEnergy / playerStats.characterDefinition.maxEnergy;
    }
}
