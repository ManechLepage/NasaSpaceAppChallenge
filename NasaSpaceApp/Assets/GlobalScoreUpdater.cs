using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalScoreUpdater : MonoBehaviour
{
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Total: " + GameManager.instance.score;
    }
}
