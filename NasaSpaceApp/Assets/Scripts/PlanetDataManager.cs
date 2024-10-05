using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDataManager : MonoBehaviour
{
    public List<PlanetarySystem> planetarySystems = new List<PlanetarySystem>();
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"First planet of first system: {planetarySystems[0].planets[0].name}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
