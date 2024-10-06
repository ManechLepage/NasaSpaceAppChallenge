using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]
public class InitialSliderManager : MonoBehaviour
{
    public Slider slider;
    public Trajectory trajectory;
    public bool isTime = true;
    public bool isAngle = false;
    public bool isVelocity = false;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Start()
    {
        slider.onValueChanged.AddListener(OnSliderChange);
        
        if (isTime)
            slider.value = trajectory.time;
        else if (isAngle) {
            slider.value = trajectory.initialAngle * Mathf.Rad2Deg - 90;
        }
        else if (isVelocity)
            slider.value = trajectory.initialVelocity;
    }

    void OnSliderChange(float value)
    {
        if (trajectory.running)
            return;
        if (isTime)
            trajectory.SetTime(value);
        else if (isAngle)
            trajectory.SetInitialAngle(value);
        else if (isVelocity)
            trajectory.SetInitialVelocity(value);
    }
}
