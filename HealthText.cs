using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    public GameObject player;

    private TextMeshProUGUI healthText;
    private CharacterStats stats;

    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        stats = player.GetComponent<CharacterStats>();
    }

    void Update()
    {
        healthText.SetText(stats.GetHealth().ToString() + " / " + stats.GetMaxHealth().ToString());
    }
}
