using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoreManager : MonoBehaviour
{
    public List<string> tutorialTexts;
    public List<string> level1Texts;
    public List<string> level2Texts;
    public List<string> level3Texts;
    public GameObject label;
    private int index = 0;
    private List<string> currentTexts;

    void Start()
    {
        currentTexts = tutorialTexts;
        label.GetComponent<TextMeshProUGUI>().text = currentTexts[0];
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            index++;
            if (index == currentTexts.Count)
            {
                if (currentTexts == tutorialTexts)
                {
                    currentTexts = level1Texts;
                    index = 0;
                }

                GameManager.instance.ChangeScene("Mission");
            }
            else
            {
                label.GetComponent<TextMeshProUGUI>().text = currentTexts[index];
            }
        }
    }
}
