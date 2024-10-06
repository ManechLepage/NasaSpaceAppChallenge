using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    public GameObject gameManager;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RoguePlanet"))
        {
            other.gameObject.GetComponent<Trajectory>().running = false;
            gameManager.GetComponent<GameManager>().score += CalculateScore(other.gameObject.transform.position.y);
        }
    }

    int CalculateScore(float distance)
    {
        float distanceRatio = MathF.Abs(distance) / 5.0f;
        return (int)(-1000 * (1 - distanceRatio));
    }
}
