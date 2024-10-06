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

        switch (GameManager.instance.level)
        {
            case 2:
                currentTexts = level2Texts;
                break;
            case 3:
                currentTexts = level3Texts;
                break;
        }
        
        if (currentTexts.Count != 0)
            label.GetComponent<TextMeshProUGUI>().text = currentTexts[0];

        /*
        For the text 4:
        HAL: Our ship has now been rendered inoperable. Nevertheless, we may still continue our mission of mapping and photographing the exoplanets in the designating star systems: Epsilon Eridani, K2-3, TRAPPIST-1, Kepler-90, HD 20782 and HIP 78530. 
        (removed TRAPPIST-1, HD 20782 and HIP 78530)
        */
    }
    void Update()
    {
        if (currentTexts.Count == 0)
            return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            index++;
            if (index == currentTexts.Count)
            {
                if (currentTexts == tutorialTexts)
                {
                    switch(GameManager.instance.level)
                    {
                        case 1:
                            currentTexts = level1Texts;
                            break;
                        case 2:
                            currentTexts = level2Texts;
                            break;
                        case 3:
                            currentTexts = level3Texts;
                            break;
                    }
                    index = 0;
                }
                else
                {
                    GameManager.instance.ChangeScene("Game");
                }
            }
            label.GetComponent<TextMeshProUGUI>().text = currentTexts[index];
        }
    }
}
