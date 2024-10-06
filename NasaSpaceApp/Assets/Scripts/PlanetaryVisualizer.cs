using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryVisualizer : MonoBehaviour
{
    public GameObject planetsData;
    public GameObject planetPrefab;
    public float max_radius = 8.5f;
    public GameObject roguePlanet;
    public GameObject angle;

    void Start()
    {
        InitializePlanets();
    }

    public float get_max_radius()
    {

        float max_radius = 0;
        foreach (PlanetData planet in planetsData.GetComponent<PlanetDataManager>().currentSystem.planets)
        {
            if (planet.semiMajor > max_radius)
            {
                max_radius = planet.semiMajor;
            }
        }
        return max_radius;
    }

    public void InitializePlanets()
    {
        foreach (PlanetData planet in planetsData.GetComponent<PlanetDataManager>().currentSystem.planets)
        {
            GameObject newPlanet = Instantiate(planetPrefab, transform);
            newPlanet.GetComponent<PlanetVisualizer>().planetData = planet;
        }
    }

    public Vector2 get_position_from_planet(PlanetData planetData)
    {
        Vector2 polarPosition = planetData.CalculatePosition(planetsData.GetComponent<PlanetDataManager>().time);
        return get_position_from_polar(polarPosition);
    }

    public Vector2 get_position_from_polar(Vector2 polarPosition)
    {
        float radius_ratio = polarPosition.x / get_max_radius();
        float radius = max_radius * radius_ratio;
        return new Vector2(radius * Mathf.Sin(polarPosition.y), radius * Mathf.Cos(polarPosition.y));
    }

    public void LaunchPlanet()
    {
        roguePlanet.GetComponent<Trajectory>().StartSimulation();
        angle.SetActive(false);
    }
}
