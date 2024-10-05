using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Planet", menuName = "Space/PlanetData", order = 2)]
public class PlanetData : ScriptableObject
{
    public double semiMajor;
    public double eccentricity;
    public double mass;

    public double initialTime;

    public double time;
    public double radius;
}
