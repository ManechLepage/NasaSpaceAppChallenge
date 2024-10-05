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
    public double initialTime;  // in s

    [Space]
    public double time;  // in s
    public double radius;  // in km
}
