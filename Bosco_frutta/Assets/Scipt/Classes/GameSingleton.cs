using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleton:MonoBehaviour {
    public static GameSingleton instance;
    public Player player;
    public float SpawnRateSeconds;
    public List<GameObject> listSpawnPoints;

    void Awake () {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }

        if(PlayerPrefs.HasKey("TotPoints")){           
            player = new Player(PlayerPrefs.GetFloat("TotPoints"));
        }
        else {
            PlayerPrefs.SetFloat("TotPoints", 0f);
            player = new Player();
        }
        
        SpawnRateSeconds = 0;
        listSpawnPoints = new List<GameObject>();
    }
}