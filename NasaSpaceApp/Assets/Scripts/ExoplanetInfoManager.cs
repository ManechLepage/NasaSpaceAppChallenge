using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExoplanetInfoManager : MonoBehaviour
{
    public PlanetData planetData;
    public GameObject planetsParent;
    public GameObject planetInfoPanel;
    public TextMeshProUGUI planetName;
    public Image preview;
    public TextMeshProUGUI planetType;
    public TextMeshProUGUI planetMass;
    public TextMeshProUGUI planetGravity;
    public TextMeshProUGUI planetDistance;
    public TextMeshProUGUI planetPeriod;

    void Start()
    {
        HidePlanetInfo();
        planetData = null;
    }

    void Update()
    {
        if (planetData != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Input.mousePosition;
                Vector2 panelPosition = planetInfoPanel.transform.position;

                if (!planetInfoPanel.GetComponent<RectTransform>().rect.Contains(mousePosition - panelPosition))
                {
                    HidePlanetInfo();
                    planetData = null;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                foreach (Transform child in planetsParent.transform)
                {
                    Vector3 position = child.position;
                    Vector3 scale = child.localScale * 2f;

                    position.y += scale.y / 2;

                    Vector2 min = new Vector2(position.x - scale.x / 2, position.y - scale.y / 2);
                    Vector2 max = new Vector2(position.x + scale.x / 2, position.y + scale.y / 2);

                    if (mousePosition.x > min.x && mousePosition.x < max.x && mousePosition.y > min.y && mousePosition.y < max.y)
                    {
                        PlanetVisualizer planetVisualizer = child.GetComponent<PlanetVisualizer>();
                        UpdatePlanetInfo(planetVisualizer.planetData, (Vector2)position);
                        ShowPlanetInfo();
                        break;
                    }
                }
            }
        }
    }
    
    public void UpdatePlanetInfo(PlanetData planetData, Vector2 position)
    {
        this.planetData = planetData;
        planetName.text = planetData.name;
        planetType.text = planetData.type.ToString();
        planetMass.text = planetData.mass.ToString() + " Earth Masses";
        planetDistance.text = planetData.semiMajor.ToString() + " AU";
        planetPeriod.text = planetData.period.ToString() + " Earth Days";

        //preview.sprite = planetData.planetSprite;
        //float gravity = 6.67f * 10f**-11f * planetData.mass / (planetData.semiMajor * 1.496f**8f)**2f;
        //planetGravity.text = 6.67f*10f**-11f *  + " m/s^2";
    }

    public void ShowPlanetInfo()
    {
        planetInfoPanel.SetActive(true);
    }

    public void HidePlanetInfo()
    {
        planetInfoPanel.SetActive(false);
    }
}
