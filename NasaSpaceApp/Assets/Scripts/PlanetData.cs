using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetData", menuName = "Space/PlanetData", order = 2)]
public class PlanetData : ScriptableObject
{
<<<<<<< Updated upstream
    public double semiMajor;  // in km
    public double eccentricity;  // range 0-1
    public double mass;  // in 1x10e24 kg

    [Space]
    public double initialTime;  // in s

    [Space]
    public double time;  // in s
    public double radius;  // in km
=======
    public double semiMajor;
    public double eccentricity;
    public double mass;
    public double period;
    public double initialTime;
    public double radius;
    public double angle;
    void CalculatePosition(double time) {
        double realTime = time + initialTime;
    }
>>>>>>> Stashed changes
}
