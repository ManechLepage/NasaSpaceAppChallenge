using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetData", menuName = "Space/PlanetData", order = 2)]
public class PlanetData : ScriptableObject
{
    public double semiMajor;  // in 10e6 km
    public double eccentricity;  // range 0-1
    public double mass;  // in 10e24 kg
    public double period;  // in s

    [Space]
    public double initialTime;  // in s, time since perihelion


    public Vector2 CalculatePosition(double time) {
        double realTime = initialTime + time;
        double meanAnomaly = 2 * Mathf.PI * realTime / period;
        //calculate eccentric anomaly
        double eccentricAnomaly = meanAnomaly;
        double delta = 1;
        while (delta > 0.0001) {
            double nextEccentricAnomaly = meanAnomaly + eccentricity * (double)Mathf.Sin(eccentricAnomaly);
            delta = Mathf.Abs(nextEccentricAnomaly - eccentricAnomaly);
            eccentricAnomaly = nextEccentricAnomaly;
        }
        //calculate true anomaly
        double trueAnomaly = 2 * Mathf.Atan(Mathf.Sqrt((1 + eccentricity) / (1 - eccentricity)) * Mathf.Tan(eccentricAnomaly / 2));
        //calculate distance
        double distance = semiMajor * (1 - eccentricity * (double)Mathf.Cos(eccentricAnomaly));
        return new Vector2(distance, trueAnomaly);
    }
}
