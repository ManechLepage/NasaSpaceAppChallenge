using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetData", menuName = "Space/PlanetData", order = 2)]
public class PlanetData : ScriptableObject
{
    public float semiMajor;  // in 10e6 km
    public float eccentricity;  // range 0-1
    public float mass;  // in 10e24 kg
    public float period;  // in s

    [Space]
    public float initialTime;  // in s, time since perihelion


    public Vector2 CalculatePosition(float time) {
        float realTime = initialTime + time;
        float meanAnomaly = 2 * Mathf.PI * realTime / period;
        //calculate eccentric anomaly
        float eccentricAnomaly = meanAnomaly;
        float delta = 1;
        while (delta > 0.0001) {
            float nextEccentricAnomaly = meanAnomaly + eccentricity * Mathf.Sin(eccentricAnomaly);
            delta = Mathf.Abs(nextEccentricAnomaly - eccentricAnomaly);
            eccentricAnomaly = nextEccentricAnomaly;
        }
        //calculate true anomaly
        float trueAnomaly = 2 * Mathf.Atan(Mathf.Sqrt((1 + eccentricity) / (1 - eccentricity)) * Mathf.Tan(eccentricAnomaly / 2));
        //calculate distance
        float distance = semiMajor * (1 - eccentricity * Mathf.Cos(eccentricAnomaly));
        return new Vector2(distance, trueAnomaly);
    }
}
