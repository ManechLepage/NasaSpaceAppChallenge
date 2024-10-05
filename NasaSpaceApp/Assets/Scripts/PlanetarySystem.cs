using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Planet", menuName = "Space/PlanetarySystem", order = 1)]
public class PlanetarySystem : ScriptableObject
{
    public StarData star;
    public List<PlanetData> planets = new List<PlanetData>();
}
