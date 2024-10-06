using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{
    public PlanetDataManager planetDataManager;

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Score: " + planetDataManager.attemptScore;
    }
}
