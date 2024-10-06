using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExoplanetInfoManager : MonoBehaviour
{
    public PlanetData planetData;
    public GameObject planetInfoPanel;
    public TextMeshProUGUI planetName;
    public Image preview;
    public TextMeshProUGUI planetType;
    public TextMeshProUGUI planetMass;
    public TextMeshProUGUI planetGravity;
    public TextMeshProUGUI planetDistance;
    public TextMeshProUGUI planetPeriod;

    public void UpdatePlanetInfo(PlanetData planetData)
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
}
