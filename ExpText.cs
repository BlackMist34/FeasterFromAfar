using UnityEngine;
using TMPro;

public class ExpText : MonoBehaviour
{
    public GameObject player;

    private TextMeshProUGUI expText;
    private CharacterStats stats;

    void Start()
    {
        expText = GetComponent<TextMeshProUGUI>();
        stats = player.GetComponent<CharacterStats>();
    }

    void Update()
    {
        expText.SetText(stats.GetExperience().ToString() + " / " + stats.GetRequiredExp().ToString());
    }
}