using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryVisualizer : MonoBehaviour
{
    public PlanetarySystem planetarySystem;

    public float get_max_radius()
    {

        float max_radius = 0;
        foreach (PlanetData planet in planetarySystem.planets)
        {
            if (planet.CalculatePosition(0).x > max_radius)
            {
                max_radius = planet.CalculatePosition(0).x;
            }
        }
        return max_radius;
    }
}
