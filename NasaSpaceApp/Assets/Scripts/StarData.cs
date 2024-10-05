using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StarType
{
    RedGiant,
    WhiteDwarf,
    NeutronStar,
    RedDwarf,
    BrownDwarf
}

[CreateAssetMenu(fileName = "StarData", menuName = "Space/StarData", order = 2)]
public class StarData : ScriptableObject
{
    public StarType type;
    public float distance;  // from Earth in 10e6 km
    public float mass;  // in 10e24 kg
}
