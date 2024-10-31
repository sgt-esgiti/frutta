using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleton:MonoBehaviour {
    public static GameSingleton instance;
    public Player player;
    public float SpawnRateSeconds;

    void Awake () {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }

        player = new Player();
        SpawnRateSeconds = 0;
    }
}