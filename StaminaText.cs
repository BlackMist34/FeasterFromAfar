using UnityEngine;
using TMPro;

public class StaminaText : MonoBehaviour
{
    public GameObject player;

    private TextMeshProUGUI staminaText;
    private CharacterStats stats;

    void Start()
    {
        staminaText = GetComponent<TextMeshProUGUI>();
        stats = player.GetComponent<CharacterStats>();
    }

    void Update()
    {
        staminaText.SetText(stats.GetStamina().ToString() + " / " + stats.GetMaxStamina().ToString());
    }
}