using UnityEngine;
using TMPro;

public class LvlText : MonoBehaviour
{
    public GameObject player;

    private TextMeshProUGUI lvlText;
    private CharacterStats stats;

    void Start()
    {
        lvlText = GetComponent<TextMeshProUGUI>();
        stats = player.GetComponent<CharacterStats>();
    }

    void Update()
    {
        lvlText.SetText(stats.GetLevel().ToString());
    }
}
