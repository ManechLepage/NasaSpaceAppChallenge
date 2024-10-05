using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Trajectory : MonoBehaviour
{
    const float G = 6.67430e-11f;  // in m^3 kg^-1 s^-2
    const float Gadjusted = G * 10e18f * 10e-24f; // in 10e6 km^3 10e24 kg^-1 s^-2
    public PlanetDataManager data;
    public List<Vector2> prevTrajectory;
    public GameObject planetVisualiser;
    public Vector2 initialPosition;
    public float initialTime;
    public float initialVelocity;
    public float initialAngle;
    public float timeStep;
    public int numSubSteps;
    public bool running;
    private float time;
    private Vector2 position;
    private Vector2 velocity;


    void Start() {
        time = initialTime;
        InitializeTrajectory();
    }

    public void InitializeTrajectory() {
        prevTrajectory = new List<Vector2>();
        position = initialPosition;
        velocity = new Vector2(initialVelocity * Mathf.Cos(initialAngle), initialVelocity * Mathf.Sin(initialAngle));
        transform.localPosition = planetVisualiser.GetComponent<PlanetaryVisualizer>().get_position_from_polar(new Vector2(initialPosition.magnitude, Mathf.Atan2(initialPosition.y, initialPosition.x)));
    }
    
    public void SetInitialTime(float time) {
        initialTime = time;
        data.time = time;
    }

    public void SetInitialVelocity(float velocity) {
        initialVelocity = velocity;
    }

    public void SetInitialAngle(float angle) {
        initialAngle = angle;
    }

    void Update() {
        if (running) {
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
                Debug.Log(acceleration);
                //calculate new position
                position += velocity * timeStep / numSubSteps;
                Debug.Log(position);
                //calculate new velocity
                velocity += acceleration * timeStep / numSubSteps;
                Debug.Log(velocity);
            }
            //reconvert position to polar
            float radius = position.magnitude;
            float angle = Mathf.Atan2(position.y, position.x);
            Vector2 lPos = planetVisualiser.GetComponent<PlanetaryVisualizer>().get_position_from_polar(new Vector2(radius, angle));
            prevTrajectory.Add(lPos);
            transform.localPosition = new Vector3(lPos.x, lPos.y, 0);       
        }
    }
}