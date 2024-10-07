using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterceptResetButtonManager : MonoBehaviour
{
    public PlanetDataManager planetDataManager;
    public Trajectory trajectory;

    public void Clicked()
    {
        if (planetDataManager.time != 0)
            planetDataManager.DidScore(0);
        trajectory.Reset();
    }
}
