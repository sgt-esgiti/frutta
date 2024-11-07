using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFruits : MonoBehaviour
{
    public GameObject SpawnList;
    public GameObject FruitList;

    List<GameObject> spawnPoints;
    List<GameObject> listFruits; 
    private float spawnRate;
    private float timer = 0f;
    bool spawn = false;

    void Start(){
        spawnRate = GameSingleton.instance.SpawnRateSeconds;
        spawnPoints = GameSingleton.instance.listSpawnPoints; // copy of spawn point list
        listFruits = FruitList.GetComponent<ObjectPool>().listfruits; // copy of fruits list
        spawn = false;
        //spawn 15 frutti
        for (int i = 0; i<15; i++){
            SpawnFruit();
        }
    }

    void Update(){
        timer += Time.deltaTime;
        if (timer >= spawnRate){
            SpawnFruit();
            timer = 0f;
        }
    }

    public void SpawnFruit(){
        while(!spawn){
            int Num_fruit = Random.Range(0,89);
            if(!listFruits[Num_fruit].activeInHierarchy){
                int Num_spawn = Random.Range(0,49);
                if(!spawnPoints[Num_spawn].activeInHierarchy){
                    listFruits[Num_fruit].transform.position = spawnPoints[Num_spawn].transform.position;
                    //assegna posizione vettore a frutto e quando raccolto lo risetti a falso
                    listFruits[Num_fruit].GetComponent<FruitScript>().posSpawn = Num_spawn; 
                    listFruits[Num_fruit].SetActive(true);
                    spawnPoints[Num_spawn].SetActive(true);
                    spawn = true;
                }
            }
        }
        spawn = false;
    }



}
