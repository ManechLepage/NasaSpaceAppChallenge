using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SystemNameUpdater : MonoBehaviour
{
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = GameManager.instance.currentSystem.star.name;
    }
}
