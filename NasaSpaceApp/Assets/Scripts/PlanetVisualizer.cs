using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetVisualizer : MonoBehaviour
{
    public PlanetData planetData;

    void Update()
    {
        Vector2 position = transform.parent.GetComponent<PlanetaryVisualizer>().get_position_from_planet(planetData);
        transform.localPosition = new Vector3(position.x, position.y, transform.position.z);
    }
}
