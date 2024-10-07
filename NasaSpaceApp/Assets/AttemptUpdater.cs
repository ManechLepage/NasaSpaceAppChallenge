using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttemptUpdater : MonoBehaviour
{
    public PlanetDataManager planetDataManager;

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = $"Attempt: {planetDataManager.attempt}/{planetDataManager.attempts}";
    }
}
