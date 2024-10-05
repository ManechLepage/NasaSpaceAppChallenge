using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetVisualizer : MonoBehaviour
{
    public PlanetData planetData;
    private float max_radius = 8.5f;
    Vector2 polarPosition;

    void Update()
    {
        transform.position = new Vector3((float)get_position().x, (float)get_position().y, transform.position.z);
    }

    Vector2 get_position()
    {
        polarPosition = planetData.CalculatePosition(0); 
        float radius_ratio = polarPosition.x / transform.parent.GetComponent<PlanetaryVisualizer>().get_max_radius();
        float radius = max_radius * radius_ratio;
        return new Vector2(radius * Mathf.Cos(polarPosition.y), radius * Mathf.Sin(polarPosition.y));
    }

}
