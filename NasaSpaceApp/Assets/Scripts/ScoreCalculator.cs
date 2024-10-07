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
        Debug.Log($"Distance: {distance}, Distance Ratio: {distanceRatio}, Time: {time}");

        return Mathf.Abs((int)(1000 * (1 - distanceRatio)));
    }
}
