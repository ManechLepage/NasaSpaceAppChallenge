using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Trajectory : MonoBehaviour
{
    const float G = 6.67430e-11f;  // in m^3 kg^-1 s^-2
    const float Gadjusted = G * 10e27f * 10e-24f; // in 10e6 km^3 10e24 kg^-1 s^-2
    public PlanetDataManager data;
    public GameObject planetVisualiser;
    public TrajectoryRenderer trajectoryRenderer;
    public Vector2 initialPosition;
    public GameObject angleArrow;
    public float time;
    public float initialVelocity;
    public float initialAngle;
    public float timeStep;
    public int numSubSteps;
    private const int trajectoryPointInterval = 20;
    private int count;
    public bool running;
    private float initialTime;
    private Vector2 position;
    private Vector2 velocity;
    public float maxAccel;

    void Start() {
        initialTime = 0;
        initialAngle = Mathf.PI / 2;
        initialVelocity = 0.005f;
        Reset();
    }

    public void Reset() {
        running = false;
        SetTime(initialTime);
        transform.localPosition = new Vector3(initialPosition.x, initialPosition.y, 0);
        //convert from screen reference frame to scaled radius polar
        float radius = new Vector2(initialPosition.x, initialPosition.y).magnitude;
        float angle = Mathf.Atan2(initialPosition.y, initialPosition.x);
        float descaled_radius = radius / planetVisualiser.GetComponent<PlanetaryVisualizer>().max_radius * planetVisualiser.GetComponent<PlanetaryVisualizer>().get_max_radius();
        position = new Vector2(descaled_radius * Mathf.Sin(angle), descaled_radius * Mathf.Cos(angle));
        SetInitialAngle(-initialAngle * Mathf.Rad2Deg);
        SetInitialVelocity(initialVelocity);
        count = 0;
    }
    
    public void SetTime(float newTime) {
        time = newTime;
        data.time = newTime;
    }

    public void SetInitialVelocity(float velocity) {
        if (running) {
            return;
        }
        initialVelocity = velocity;
        angleArrow.transform.localScale = new Vector3( 1, velocity * 400, 1);
    }

    public void SetInitialAngle(float angle) {
        if (running) {
            return;
        }
        initialAngle = -angle * Mathf.Deg2Rad;
        angleArrow.transform.localRotation = Quaternion.Euler(0, 0, angle);
    }

    public void StartSimulation() {
        if (running) {
            return;
        }
        initialTime = time;
        maxAccel = 0;
        count = 0;
        running = true;
        trajectoryRenderer.fadeTrajectories();
        trajectoryRenderer.newLaunch();
        velocity = new Vector2(initialVelocity * Mathf.Cos(initialAngle), initialVelocity * Mathf.Sin(initialAngle));
    }

    void Update() {
        if (!running) {
            return;
        }
        count++;
        for (int i = 0; i < numSubSteps; i++) {
            SetTime((time + timeStep * 5 / numSubSteps));
            Vector2 acceleration = new Vector2(0, 0);
            //calculate positions of planets
            foreach (PlanetData planet in data.currentSystem.planets) {
                Vector2 polar = planet.CalculatePosition(time);
                Vector2 planetPosition = new Vector2(polar.x * Mathf.Cos(polar.y), polar.x * Mathf.Sin(polar.y));
                //calculate acceleration from planet on planet
                Vector2 direction = planetPosition - position;
                float distance = direction.magnitude;
                float accelerationMag = System.Math.Min(1e-5f, Gadjusted * planet.mass / (distance * distance));
                if (accelerationMag > maxAccel) {
                    maxAccel = accelerationMag;
                }
                acceleration += accelerationMag * direction.normalized;
            }
            acceleration *= 0.7f;
            //calculate acceleration from sun on planet
            Vector2 directionToSun = -position;
            float solarDistance = directionToSun.magnitude;
            float solarAccelerationMag = Gadjusted * data.currentSystem.star.mass / (solarDistance * solarDistance);
            acceleration += solarAccelerationMag * directionToSun.normalized / 10e7f;
            //calculate new position
            position += velocity * timeStep / numSubSteps;
            //calculate new velocity
            velocity += acceleration * timeStep / numSubSteps;
        }
        angleArrow.transform.localRotation = Quaternion.Euler(0, 0, -Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg);
        angleArrow.transform.localScale = new Vector3(1, velocity.magnitude * 400, 1);
        //reconvert position to polar
        float radius = position.magnitude;
        float angle = Mathf.Atan2(position.y, position.x);
        Vector2 lPos = planetVisualiser.GetComponent<PlanetaryVisualizer>().get_position_from_polar(new Vector2(radius, angle));
        if (count == trajectoryPointInterval) {
            trajectoryRenderer.addTrajectoryPoint(lPos);
            count = 0;
        }
        transform.localPosition = new Vector3(lPos.x, lPos.y, 0);       
    }
}