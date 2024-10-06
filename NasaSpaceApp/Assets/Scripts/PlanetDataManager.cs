using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDataManager : MonoBehaviour
{
    public Trajectory roguePlanetTrajectory;

    public float time = 0;
    
    void Awake()
    {
        time = roguePlanetTrajectory.time;
        foreach (PlanetData planet in GameManager.instance.currentSystem.planets)
        {
            planet.initialPosition = Random.Range(-planet.period / 8, planet.period / 8);
        }
    }

    void Update()
    {
        //roguePlanetTrajectory.SetInitialTime(time + Time.deltaTime);
    }
}
