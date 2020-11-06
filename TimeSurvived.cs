using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeSurvived : MonoBehaviour
{
    private TextMeshProUGUI text;
    private GameObject timeManager;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        timeManager = GameObject.FindGameObjectWithTag("TimeManager");
    }

    private void Start()
    {
        text.text = timeManager.GetComponent<TimeManager>().GetTime();
    }
}
