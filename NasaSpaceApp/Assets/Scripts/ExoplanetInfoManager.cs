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
    public GameObject triangle;

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
        planetMass.text = planetData.mass.ToString() + " x Earth";
        planetDistance.text = planetData.semiMajor.ToString() + " AU";
        planetPeriod.text = (Mathf.Round(planetData.period / 31557600f * 1000f) / 1000f).ToString() + " Years";

        //preview.sprite = planetData.planetSprite;
        //float gravity = 6.67f * 10f**-11f * planetData.mass / (planetData.semiMajor * 1.496f**8f)**2f;
        //planetGravity.text = 6.67f*10f**-11f *  + " m/s²";

        Vector2 screenToWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Rect panelRect = planetInfoPanel.GetComponent<RectTransform>().rect;
        Vector2 panelSize = new Vector2(-panelRect.width, -panelRect.height);
        Vector2 panelWorldSize = Camera.main.ScreenToWorldPoint(panelSize);
        panelWorldSize = new Vector2(Mathf.Abs(panelWorldSize.x), Mathf.Abs(panelWorldSize.y));

        bool right = position.x + panelWorldSize.x < screenToWorld.x * 1.67857142857f;
        if (right)
            planetInfoPanel.transform.position = new Vector2(position.x + panelWorldSize.x / 4, position.y);
        else
            planetInfoPanel.transform.position = new Vector2(position.x - panelWorldSize.x / 4, position.y);
        
        planetInfoPanel.transform.position = new Vector2(planetInfoPanel.transform.position.x, planetInfoPanel.transform.position.y);
        Vector2 panelScreenPosition = Camera.main.WorldToScreenPoint(planetInfoPanel.transform.position);
        planetInfoPanel.transform.position = panelScreenPosition;

        if (!right)
        {
            float rotationToGetTo180 = 180 - triangle.transform.rotation.eulerAngles.y;
            triangle.transform.Rotate(new Vector3(0, rotationToGetTo180, 0));
            triangle.transform.position = new Vector2(panelScreenPosition.x + panelRect.width / 1.5f + 6.7f, panelScreenPosition.y);
        }
        else
        {
            float rotationToGetTo0 = 0 - triangle.transform.rotation.eulerAngles.y;
            triangle.transform.Rotate(new Vector3(0, rotationToGetTo0, 0));
            triangle.transform.position = new Vector2(panelScreenPosition.x - panelRect.width / 2f - 6.7f, panelScreenPosition.y);
        }
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
