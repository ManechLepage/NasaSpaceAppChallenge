using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this class should not be deleted when the scene is reloaded

public class GameManager : MonoBehaviour
{
    public int score;
    public List<PlanetarySystem> planetarySystems = new List<PlanetarySystem>();
    public PlanetarySystem currentSystem;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        currentSystem = planetarySystems[0];
    }

    public void ChangeScene(string sceneName)
    {
        if (sceneName == "Mission")
        {
            int index = planetarySystems.IndexOf(currentSystem);
            if (index == planetarySystems.Count - 1)
            {
                index = -1;
            }
            currentSystem = planetarySystems[index + 1];
        }
        
        SceneManager.LoadScene(sceneName);
    }
}
