using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]
public class TimeSliderManager : MonoBehaviour
{
    public Slider slider;
    public PlanetDataManager planetDataManager;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Start()
    {
        slider.onValueChanged.AddListener(OnSliderChange);
        slider.value = planetDataManager.time;
    }

    void OnSliderChange(float value)
    {
        planetDataManager.time = value;
    }
}
