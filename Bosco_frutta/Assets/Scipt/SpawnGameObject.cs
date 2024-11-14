using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SpawnGameObject : MonoBehaviour
{
    public static SpawnGameObject instance;   

    // Nome del file JSON da caricare
    public string jsonFileName = "spawnPoints.json";

    void Start()
    {
        LoadGameObjectsFromJson();
    }

    void LoadGameObjectsFromJson()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, jsonFileName);
        
        // Verifica se il file esiste
        if (File.Exists(filePath))
        {
            // Legge il contenuto del file JSON
            string json = File.ReadAllText(filePath);

            SpawnPointListWrapper wrapper = JsonUtility.FromJson<SpawnPointListWrapper>(json);
            
            if (wrapper != null && wrapper.spawnPoints != null)
            {
                // Per ogni punto di spawn, crea un GameObject vuoto e impostalo nella posizione corretta
                foreach (var spawnPoint in wrapper.spawnPoints)
                {
                    GameObject newGameObject = new GameObject("SpawnPoint");  
                    newGameObject.transform.position = new Vector3(spawnPoint.x, spawnPoint.y, spawnPoint.z); 
                    newGameObject.SetActive(false);
                    GameSingleton.instance.listSpawnPoints.Add(newGameObject);
                }
            }
            else
            {
                Debug.LogError("Errore durante la deserializzazione del JSON. La lista dei punti di spawn è null.");
            }
        }
        else
        {
            Debug.LogError("File JSON non trovato: " + filePath);
        }
    }

}
