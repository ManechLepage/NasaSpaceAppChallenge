using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContourVisualiser : MonoBehaviour
{
    public GameObject contourPrefab;
    public int numContours;
    public int initialForce;
    public int step;
    const float G = 6.67430e-11f;  // in m^3 kg^-1 s^-2
    const float Gadjusted = G * 10e27f * 10e-24f; // in 10e6 km^3 10e24 kg^-1 s^-2
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numContours; i++) {
            int force = initialForce + i * step;
            //Fg  = G * m1 * m2 / r^2
            //r = sqrt(G * m1 * m2 / Fg)
            float distance = Mathf.Sqrt(Gadjusted * gameObject.GetComponent<PlanetVisualizer>().planetData.mass * force);
            GameObject contour = Instantiate(contourPrefab, transform);
            contour.transform.localScale = new Vector3(distance, distance, 1);
            contour.transform.localPosition = new Vector3(0, -distance / 4 + gameObject.transform.localScale.y / 2, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
