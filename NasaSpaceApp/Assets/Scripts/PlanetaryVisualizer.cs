using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryVisualizer : MonoBehaviour
{
    public PlanetarySystem planetarySystem;

    double get_max_radius()
    {
        double max_radius = 0;
        foreach (PlanetData planet in planetarySystem.planets)
        {
            if (planet.radius > max_radius)
            {
                max_radius = planet.radius;
            }
        }
        return max_radius;
    }
}
