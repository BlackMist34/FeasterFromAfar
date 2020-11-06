using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
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
        image.fillAmount = playerStats.characterDefinition.currentHealth / playerStats.characterDefinition.maxHealth;
    }
}
