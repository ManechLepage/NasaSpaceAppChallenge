using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDataManager : MonoBehaviour
{
    public List<PlanetarySystem> planetarySystems = new List<PlanetarySystem>();
    public PlanetarySystem currentSystem;
    public Trajectory roguePlanetTrajectory;

    public float time = 0;
    
    void Awake()
    {
        currentSystem = planetarySystems[1];
        time = roguePlanetTrajectory.time;
        foreach (PlanetData planet in currentSystem.planets)
        {
            planet.initialPosition = Random.Range(-planet.period / 8, planet.period / 8);
        }
    }

    void Update()
    {
        //roguePlanetTrajectory.SetInitialTime(time + Time.deltaTime);
    }
}
