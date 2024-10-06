using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Score: " + GameManager.instance.score;
    }
}
