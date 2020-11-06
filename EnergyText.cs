using UnityEngine;
using TMPro;

public class EnergyText : MonoBehaviour
{
    public GameObject player;

    private TextMeshProUGUI energyText;
    private CharacterStats stats;

    void Start()
    {
        energyText = GetComponent<TextMeshProUGUI>();
        stats = player.GetComponent<CharacterStats>();
    }

    void Update()
    {
        energyText.SetText(stats.GetEnergy().ToString() + " / " + stats.GetMaxEnergy().ToString());
    }
}