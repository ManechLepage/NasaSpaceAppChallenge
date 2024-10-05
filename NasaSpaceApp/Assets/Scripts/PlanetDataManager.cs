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
        currentSystem = planetarySystems[0];
        time = roguePlanetTrajectory.initialTime;
    }

    void Update()
    {
        roguePlanetTrajectory.SetInitialTime(time + Time.deltaTime);
    }
}
