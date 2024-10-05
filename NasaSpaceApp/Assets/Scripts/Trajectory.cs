using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Trajectory : MonoBehaviour
{
    
    const float G = 6.67430e-11f;  // in m^3 kg^-1 s^-2
    const float Gadjusted = G * 10e18f * 10e-24f; // in 10e6 km^3 10e24 kg^-1 s^-2
    public PlanetDataManager data;
    public GameObject planetVisualiser;
    public Vector2 initialPosition;
    public float initialTime;
    public float initialVelocity;
    public float initialAngle;
    public float timeStep;
    public int numSubSteps;
    private float time;
    private Vector2 position;
    private Vector2 velocity;


    void Start() {
        time = initialTime;
    }
    void Update() {
        for (int i = 0; i < numSubSteps; i++) {
            time += timeStep / numSubSteps;
            Vector2 acceleration = new Vector2(0, 0);
            //calculate positions of planets
            foreach (PlanetData planet in data.currentSystem.planets) {
                Vector2 polar = planet.CalculatePosition(time);
                Vector2 planetPosition = new Vector2(polar.x * Mathf.Cos(polar.y), polar.x * Mathf.Sin(polar.y));
                //calculate acceleration from planet on planet
                Vector2 direction = planetPosition - position;
                float distance = direction.magnitude;
                float accelerationMag = Gadjusted * planet.mass / (distance * distance);
                acceleration += accelerationMag * direction.normalized;
            }
            //calculate acceleration from sun on planet
            Vector2 directionToSun = -position;
            float solarDistance = directionToSun.magnitude;
            float solarAccelerationMag = Gadjusted * data.currentSystem.star.mass / (solarDistance * solarDistance);
            acceleration += solarAccelerationMag * directionToSun.normalized;
            //calculate new position
            position += velocity * timeStep / numSubSteps;
            //calculate new velocity
            velocity += acceleration * timeStep / numSubSteps;
        }
    }
}