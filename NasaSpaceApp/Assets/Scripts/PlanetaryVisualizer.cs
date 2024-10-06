using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryVisualizer : MonoBehaviour
{
    public GameObject planetsData;
    public GameObject planetPrefab;
    public float max_radius = 8.5f;
    public float max_planetary_radius = 0.5f;
    const float a = 2.5f;
    public GameObject angle;

    void Start()
    {
        InitializePlanets();
    }

    public float get_max_radius()
    {

        float max_radius = 0;
        foreach (PlanetData planet in GameManager.instance.currentSystem.planets)
        {
            if (planet.semiMajor > max_radius)
            {
                max_radius = planet.semiMajor;
            }
        }
        return max_radius;
    }

    public float get_max_planetaryRadius() {
        float max_radius = 0;
        foreach (PlanetData planet in GameManager.instance.currentSystem.planets)
        {
            if (planet.radius > max_radius)
            {
                max_radius = planet.radius;
            }
        }
        return max_radius;
    }

    public float get_max_mass() {
        float max_mass = 0;
        foreach (PlanetData planet in GameManager.instance.currentSystem.planets)
        {
            if (planet.mass > max_mass)
            {
                max_mass = planet.mass;
            }
        }
        return max_mass;
    }

    public void InitializePlanets()
    {
        foreach (PlanetData planet in GameManager.instance.currentSystem.planets)
        {
            GameObject newPlanet = Instantiate(planetPrefab, transform);
            newPlanet.GetComponent<PlanetVisualizer>().planetData = planet;
            newPlanet.GetComponent<SpriteRenderer>().color = planet.color;
            float scale = Mathf.Log(a * planet.radius / get_max_planetaryRadius() + 1, 10) / Mathf.Log(a + 1, 10) * max_planetary_radius;
            Debug.Log("Max radius: " + get_max_planetaryRadius() + " Planet radius: " + planet.radius + " Scale: " + scale);
            newPlanet.transform.localScale = new Vector3(scale, scale, 1);
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
}
