using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Planet", menuName = "Space/PlanetData", order = 2)]
public class PlanetData : ScriptableObject
{
    public double radius; // axe semi-majeur
    public double eccentricity;
    public double mass;
}
