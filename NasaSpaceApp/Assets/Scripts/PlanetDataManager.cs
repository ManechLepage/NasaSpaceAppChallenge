using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDataManager : MonoBehaviour
{
    public Trajectory roguePlanetTrajectory;
    public int attempts = 3;
    [Space]
    public float time = 0;
    public int attempt = 1;
    public List<int> scores = new List<int>();
    [Space]
    public int attemptScore = 0;
    
    void Awake()
    {
        time = roguePlanetTrajectory.time;
        foreach (PlanetData planet in GameManager.instance.currentSystem.planets)
        {
            planet.initialPosition = Random.Range(-planet.period / 8, planet.period / 8);
        }
    }

    public void DidScore(int score)
    {
        attemptScore = score;
        Debug.Log($"Scored {score} points for attempt {attempt}");
        
        scores.Add(score);
        attempt++;
        if (attempt > attempts)
        {
            GameManager.instance.level += 1;
            GameManager.instance.ChangeScene("Lore");

            int maxScore = 0;
            foreach (int s in scores)
            {
                if (s > maxScore)
                    maxScore = s;
            }
            GameManager.instance.score += maxScore;
        }
    }

    void Update()
    {
        //roguePlanetTrajectory.SetInitialTime(time + Time.deltaTime);
    }
}
