using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{
    public GameObject gameManager;

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Score: " + gameManager.GetComponent<GameManager>().score;
    }
}
