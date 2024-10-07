using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    public PlanetDataManager planetDataManager;
    public GameObject soundEffect;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected");
        if (other.gameObject.CompareTag("RoguePlanet"))
        {
            //other.gameObject.SetActive(false);
            planetDataManager.DidScore(CalculateScore(other.gameObject.transform.position.y));
            other.gameObject.GetComponent<Trajectory>().Reset();
            soundEffect.GetComponent<AudioSource>().Play();
        }
    }

    int CalculateScore(float distance)
    {
        float distanceRatio = MathF.Abs(distance) / 5.0f;
        int time = (int)planetDataManager.time;
        // scale of the time in +-50000 to infinite (usually 100000)

        int distanceRationScore = (int)((float)Mathf.Abs((int)(1000f * (1f - distanceRatio))) / 1.75f); // range 0 to 571 (1000/1.75 = 571)
        // time score multiplier : between 0.5 to 2, if the time is really high (ex. 150000) closer to 1.75 and if time is really low (ex. 50000) closer to 0.75
        float timeScoreMultiplier = 0.75f + (1.25f / (1f + Mathf.Exp(-0.000015f * time + 8f)));

        int score = (int)(distanceRationScore * timeScoreMultiplier); // range 0 to 999 (571*1.75 = 999)
        return score;
    }
}
