using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterceptResetButtonManager : MonoBehaviour
{
    public PlanetDataManager planetDataManager;
    public Trajectory trajectory;

    public void Clicked()
    {
        planetDataManager.DidScore(0);
        trajectory.Reset();
    }
}
