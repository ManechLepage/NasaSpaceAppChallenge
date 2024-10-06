using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this class should not be deleted when the scene is reloaded

public class GameManager : MonoBehaviour
{
    public int score;
    public List<PlanetarySystem> planetarySystems = new List<PlanetarySystem>();
    public int level = 1;
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
        level = 1;
    }

    public void ChangeScene(string sceneName)
    {
        if (sceneName == "Lore" && level <= planetarySystems.Count)
        {
            currentSystem = planetarySystems[level - 1];
        }
        SceneManager.LoadScene(sceneName);
    }
}
