using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContourVisualiser : MonoBehaviour
{
    public GameObject contourPrefab;
    public int numContours;
    public int initialForce;
    public int step;
    const float desired_max_contour = 6f;
    const float G = 6.67430e-11f;  // in m^3 kg^-1 s^-2
    const float Gadjusted = G * 10e27f * 10e-24f; // in 10e6 km^3 10e24 kg^-1 s^-2
    float radiusFromForce(float mass, float force) {
        //Fg  = G * m1 * m2 / r^2
        //r = sqrt(G * m1 * m2 / Fg)
        return Mathf.Sqrt(Gadjusted * mass / force);
    }
    // Start is called before the first frame update
    void Start()
    {   
        float maxDistance = radiusFromForce(gameObject.GetComponentInParent<PlanetaryVisualizer>().get_max_mass(), initialForce - (numContours - 1) * step);
        for (int i = 0; i < numContours; i++) {
            int force = initialForce - i * step;
            float distance = radiusFromForce(gameObject.GetComponent<PlanetVisualizer>().planetData.mass, force);
            float scaled_distance = distance / maxDistance * desired_max_contour;
            GameObject contour = Instantiate(contourPrefab, transform);
            contour.GetComponent<DrawRing>().radius = scaled_distance;
            contour.transform.localPosition = new Vector3(0, 1 + transform.localScale.y / 2, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
