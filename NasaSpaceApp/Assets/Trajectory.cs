using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public PlanetDataManager data;
    public float initialTime;
    public float initialVelocity;
    public float initialAngle;
    public unsigned int numPoints;
    public unsigned int numSubSteps;
    public float timeStep;
    // Start is called before the first frame update
    void Start()
    {

    }

    void CalculateTrajectory() {
        public List<Vector2> trajectory = new List<Vector2>();
        Vector2 position = new Vector2(0, 0);
        for (int i = 0; i < numPoints; i++) {
            for (int j = 0; j < numSubSteps; j++) {
                float time = initialTime + i * timeStep + j * timeStep / numSubSteps;
                //calculate positions of planets
                foreach (PlanetData planet in data.currentSystem.planets) {
                    Vector2 polar = planet.CalculatePosition(time);
                    Vector2 position = new Vector2(polar.x * Mathf.Cos(polar.y), polar.x * Mathf.Sin(polar.y));
                    //calculate acceleration from planet on 
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
