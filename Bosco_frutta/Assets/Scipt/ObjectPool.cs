using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    //Oggetti dei vari frutti con serialize field per poterlo vedere su unity
    [SerializeField] private GameObject ApplePrefab; //4 points -> 20 amount
    [SerializeField] private GameObject PearPrefab; // 5 points -> 20 amount
    [SerializeField] private GameObject OrangePrefab; // 7 points -> 15 amount
    [SerializeField] private GameObject PomegranatePrefab; // 19 points -> 10 amount
    [SerializeField] private GameObject FigPrefab; // 11 points -> 10 amount
    [SerializeField] private GameObject khakiPrefab; // 9 points -> 15 amount
    public List<GameObject> listfruits = new List<GameObject>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        GameObject tmp;

        int amountToPool = 20;
        //pool apple
        for (int i=0; i < amountToPool; i++){
            tmp = Instantiate(ApplePrefab, new Vector3(10000,0,10000), new Quaternion(-90,0,0,0));
            //set points
            tmp.GetComponent<FruitScript>().fruit = new Fruit(4);
            tmp.SetActive(false);
            listfruits.Add(tmp);
        }

        //pool pear
        for (int i=0; i<amountToPool; i++){
            tmp = Instantiate(PearPrefab, new Vector3(10000,0,10000), new Quaternion(-90,0,0,0));
            //set points
            tmp.GetComponent<FruitScript>().fruit = new Fruit(5);
            tmp.SetActive(false);
            listfruits.Add(tmp);
        }

        amountToPool = 15;
        //orange pool
        for (int i=0; i<amountToPool; i++){
            tmp = Instantiate(OrangePrefab, new Vector3(10000,0,10000), new Quaternion(-90,0,0,0));
            //set points
            tmp.GetComponent<FruitScript>().fruit = new Fruit(7);
            tmp.SetActive(false);
            listfruits.Add(tmp);
        }

        //khaki pool
        for (int i=0; i<amountToPool; i++){
            tmp = Instantiate(khakiPrefab, new Vector3(10000,0,10000), new Quaternion(-90,0,0,0));
            //set points
            tmp.GetComponent<FruitScript>().fruit = new Fruit(9);
            tmp.SetActive(false);
            listfruits.Add(tmp);
        }

        amountToPool = 10;
        //Fig pool
        for (int i=0; i<amountToPool; i++){
            tmp = Instantiate(FigPrefab, new Vector3(10000,0,10000), new Quaternion(-90,0,0,0));
            //set points
            tmp.GetComponent<FruitScript>().fruit = new Fruit(11);
            tmp.SetActive(false);
            listfruits.Add(tmp);
        }

        //pomegranade pool
        for (int i=0; i<amountToPool; i++){
            tmp = Instantiate(PomegranatePrefab, new Vector3(10000,0,10000), new Quaternion(-90,0,0,0));
            //set points
            tmp.GetComponent<FruitScript>().fruit = new Fruit(19);
            tmp.SetActive(false);
            listfruits.Add(tmp);
        }

    }

}
