using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDataManager : MonoBehaviour
{
    public List<PlanetarySystem> planetarySystems = new List<PlanetarySystem>();
    public PlanetarySystem currentSystem;
    
    void Start()
    {
        currentSystem = planetarySystems[0];
    }

    void Update()
    {
        
    }
}
