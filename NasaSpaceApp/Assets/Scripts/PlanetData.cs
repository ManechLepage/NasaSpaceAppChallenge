using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetData", menuName = "Space/PlanetData", order = 2)]
public class PlanetData : ScriptableObject
{
    public double semiMajor;  // in km
    public double eccentricity;  // range 0-1
    public double mass;  // in 1x10e24 kg

    [Space]
    public double initialTime;  // in s

    [Space]
    public double time;  // in s
    public double radius;  // in km
}
