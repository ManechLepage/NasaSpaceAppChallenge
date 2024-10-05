using System.Collections;
using System.Collections.Generic;
using UnityEngine;

const float G = 6.67430e-11;  // in m^3 kg^-1 s^-2
const float Gadjusted = G * 10e18 * 10e-24; // in 10e6 km^3 10e24 kg^-1 s^-2
public class Trajectory : MonoBehaviour
{
    public PlanetDataManager data;
    public Vector2 initialPosition;
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

    List<Vector2> CalculateTrajectory() {
        public List<Vector2> trajectory = new List<Vector2>();
        Vector2 position = initialPosition;
        Vector2 velocity = new Vector2(initialVelocity * Mathf.Cos(initialAngle), initialVelocity * Mathf.Sin(initialAngle));
        for (int i = 0; i < numPoints; i++) {
            for (int j = 0; j < numSubSteps; j++) {
                float time = initialTime + i * timeStep + j * timeStep / numSubSteps;
                Vector2 acceleration = new Vector2(0, 0);
                //calculate positions of planets
                foreach (PlanetData planet in data.currentSystem.planets) {
                    Vector2 polar = planet.CalculatePosition(time);
                    Vector2 planetPosition = new Vector2(polar.x * Mathf.Cos(polar.y), polar.x * Mathf.Sin(polar.y));
                    //calculate acceleration from planet on planet
                    Vector2 direction = planetPosition - position;
                    float distance = direction.magnitude;
                    accelerationMag = Gadjusted * planet.mass / (distance * distance);
                    acceleration += accelerationMag * direction.normalized;
                }
                //calculate acceleration from sun on planet
                Vector2 direction = -position;
                float distance = direction.magnitude;
                accelerationMag = Gadjusted * data.currentSystem.star.mass / (distance * distance);
                acceleration += accelerationMag * direction.normalized;
                //calculate new position
                position += velocity * timeStep / numSubSteps;
                //calculate new velocity
                velocity += acceleration * timeStep / numSubSteps;
            }
            //convert position to polar coordinates
            float distance = position.magnitude;
            float angle = Mathf.Atan2(position.y, position.x);
            trajectory.Add(new Vector2(distance, angle));
        }
        return trajectory;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
