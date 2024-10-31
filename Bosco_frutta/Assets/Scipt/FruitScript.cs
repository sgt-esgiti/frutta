using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    public Fruit fruit;
    private Player playerInst;

    void Start(){
        playerInst = GameSingleton.instance.player;
    }


    public void AddPoints(){
        playerInst.AddGamePoints(fruit.Points);
    }

}
