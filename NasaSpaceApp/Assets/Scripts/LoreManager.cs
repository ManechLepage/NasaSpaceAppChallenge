using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoreManager : MonoBehaviour
{
    public List<string> tutorialTexts;
    public List<string> level1Texts; //epsilon eridani
    public List<string> level2Texts; // k2-3
    public List<string> level3Texts; // Kepler-90
    public List<string> level4Texts; // TRAPPIST-1
    public List<string> endGameTexts;
    public GameObject label;
    private int index = 0;
    private List<string> currentTexts;
    public GameObject soundEffect;

    void Start()
    {
        switch (GameManager.instance.level)
        {
            case 1:
                currentTexts = tutorialTexts;
                break;
            case 2:
                currentTexts = level2Texts;
                break;
            case 3:
                currentTexts = level3Texts;
                break;
            case 4:
                currentTexts = level4Texts;
                break;
            default:
                currentTexts = endGameTexts;
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
            soundEffect.GetComponent<AudioSource>().Play();
            index++;
            if (index == currentTexts.Count)
            {
                if (currentTexts == endGameTexts)
                {
                    index--;
                }
                else if (currentTexts == tutorialTexts)
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
                        case 4:
                            currentTexts = level4Texts;
                            break;
                    }
                    index = 0;
                }
                else
                {
                    GameManager.instance.ChangeScene("Game");
                }
            }
            if (index < currentTexts.Count && currentTexts.Count != 0)
            {
                label.GetComponent<TextMeshProUGUI>().text = currentTexts[index];
            }
        }
    }
}
