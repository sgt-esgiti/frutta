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
    
        //funzionano bene queste 3 righe -> se non funziona è un problema della riga 17 (riprova quando singleton partità dalla stanza)
        gameObject.SetActive(false);
        gameObject.transform.position = new Vector3 (10000,0,10000);
        gameObject.transform.rotation = new Quaternion (-90,0,0,0);
    }

}
