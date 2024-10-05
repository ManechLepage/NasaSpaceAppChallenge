using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetVisualizer : MonoBehaviour
{
    public PlanetData planetData;
    private double max_radius = 8.5;

    void Update()
    {
        transform.position = new Vector3((float)get_position().x, (float)get_position().y, transform.position.z);
    }

    double get_position()
    {
        float radius_ratio = planetData.radius / transform.parent.GetComponent<PlanetaryVisualizer>().get_max_radius();
        float radius = max_radius * radius_ratio;
        return new Vector2(radius * Mathf.Cos(planetData.angle), radius * Mathf.Sin(planetData.angle));
    }

}
