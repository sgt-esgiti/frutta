using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    public int posSpawn=0;
    public Fruit fruit;

    private Player playerInst;
    

    void Start(){
        playerInst = GameSingleton.instance.player;
    }
    

    public void AddPoints(){
        
        
        if(playerInst != null){
            playerInst.AddGamePoints(fruit.Points);
        }
            
    

        gameObject.SetActive(false);
        gameObject.transform.position = new Vector3 (10000,0,10000);
        gameObject.transform.rotation = new Quaternion (-90,0,0,0);
    }

}
