using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class UpgradeCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtSpeLv;
    [SerializeField] private TextMeshProUGUI txtMolLv;
    [SerializeField] private TextMeshProUGUI txtSpawnLv;
    [SerializeField] private TextMeshProUGUI txtSpeValue;
    [SerializeField] private TextMeshProUGUI txtMolValue;
    [SerializeField] private TextMeshProUGUI txtSpawnValue;
    [SerializeField] private TextMeshProUGUI txtSpeCost;
    [SerializeField] private TextMeshProUGUI txtMolCost;
    [SerializeField] private TextMeshProUGUI txtSpawnCost;

    [SerializeField] private TextMeshProUGUI txtTotPoints;

    [SerializeField] private GameObject buttonSpeed;
    [SerializeField] private GameObject buttonMol;
    [SerializeField] private GameObject buttonSpawn;
    
    //creation of Speed, MolScore and SpawnRate array of levels
    private Level[] speedLevels = {
        new Level(0,1.5f),
        new Level(25,2),
        new Level(100,3),
        new Level(250,4),
        new Level(500,5),
        new Level(1000,10)
    };

    private Level[] molScoreLevels = {
        new Level(0,1),
        new Level(25,1.5f),
        new Level(100,2),
        new Level(250,2.5f),
        new Level(500,3),
        new Level(1000,4)
    };

    private Level[] spawnRateLevels = {
        new Level(0,15),
        new Level(25,10),
        new Level(100,8),
        new Level(250,6),
        new Level(500,4),
        new Level(1000,1)
    };

    private Player playerInst;
    private Upgrade Speed;
    private Upgrade MolScore;
    private Upgrade SpawnRate;

    void Start()
    {
        playerInst = GameSingleton.instance.player;

        buttonSpeed.SetActive(true);
        buttonMol.SetActive(true);
        buttonSpawn.SetActive(true);

        Speed = new Upgrade(speedLevels);
        MolScore = new Upgrade(molScoreLevels);
        SpawnRate = new Upgrade(spawnRateLevels);

        if(PlayerPrefs.HasKey("Speed")){
            //load
            Speed.Lv = PlayerPrefs.GetInt("Speed");
            MolScore.Lv = PlayerPrefs.GetInt("MolScore");
            SpawnRate.Lv = PlayerPrefs.GetInt("SpawnRate");
            playerInst.TotalPoints = PlayerPrefs.GetFloat("TotPoints");
        }
        else {
            //set and create
            PlayerPrefs.SetInt("Speed", 0);
            PlayerPrefs.SetInt("MolScore", 0);
            PlayerPrefs.SetInt("SpawnRate", 0);
            PlayerPrefs.SetFloat("TotPoints", 0);
        }

        //change text when game start
        ChangeSpeTexts();
        ChangeMolTexts();
        ChangeSpawnTexts();
        txtTotPoints.text = playerInst.TotalPoints.ToString();

        //change player and game stats
        playerInst.MovementSpeed = Speed.livello[Speed.Lv].Value;
        playerInst.PointsMultiplier = MolScore.livello[MolScore.Lv].Value;
        GameSingleton.instance.SpawnRateSeconds = SpawnRate.livello[SpawnRate.Lv].Value;
    }

    void ChangeSpeTexts() {
        if (Speed.Lv!=5){
            txtSpeLv.text = Speed.Lv.ToString();
            txtSpeValue.text = Speed.livello[Speed.Lv].Value.ToString();
            txtSpeCost.text = Speed.livello[Speed.Lv+1].Cost.ToString() + " points";;
        }
        else {
            txtSpeLv.text = "MAX";
            txtSpeValue.text = Speed.livello[Speed.Lv].Value.ToString();
            buttonSpeed.SetActive(false);
        }
    }

    void ChangeMolTexts() {
        if (MolScore.Lv != 5){
            txtMolLv.text = MolScore.Lv.ToString();
            txtMolValue.text = MolScore.livello[MolScore.Lv].Value.ToString();
            txtMolCost.text = MolScore.livello[MolScore.Lv+1].Cost.ToString() + " points";;
        }
        else {
            txtMolLv.text = "MAX";
            txtMolValue.text = MolScore.livello[MolScore.Lv].Value.ToString();
            buttonMol.SetActive(false);
        }
    }

    void ChangeSpawnTexts() {
        if (SpawnRate.Lv != 5){
            txtSpawnLv.text = SpawnRate.Lv.ToString();
            txtSpawnValue.text = SpawnRate.livello[SpawnRate.Lv].Value.ToString() + "s";
            txtSpawnCost.text = Speed.livello[SpawnRate.Lv+1].Cost.ToString() + " points";
        }
        else {
            txtSpawnLv.text = "MAX";
            txtSpawnValue.text = SpawnRate.livello[SpawnRate.Lv].Value.ToString() + "s";
            buttonSpawn.SetActive(false);
        } 
    }

    public void UpgradeSpeed(){
        if(playerInst.TotalPoints>=Speed.livello[Speed.Lv+1].Cost){
            playerInst.TotalPoints-=Speed.livello[Speed.Lv+1].Cost;
            txtTotPoints.text = playerInst.TotalPoints.ToString("0");
            Speed.Lv++;
            playerInst.MovementSpeed = Speed.livello[Speed.Lv].Value;
            PlayerPrefs.SetInt("Speed", Speed.Lv);
            ChangeSpeTexts();
        }
    }
    public void UpgradeMolScore(){
        if(playerInst.TotalPoints>=MolScore.livello[MolScore.Lv+1].Cost){
            playerInst.TotalPoints-=MolScore.livello[MolScore.Lv+1].Cost;
            txtTotPoints.text = playerInst.TotalPoints.ToString("0");
            MolScore.Lv++;
            playerInst.PointsMultiplier = MolScore.livello[MolScore.Lv].Value;
            PlayerPrefs.SetInt("MolScore", MolScore.Lv);
            ChangeMolTexts();
        }
    }
    public void UpgradeSpawnRate(){
        if(playerInst.TotalPoints>=SpawnRate.livello[SpawnRate.Lv+1].Cost){
            playerInst.TotalPoints-=SpawnRate.livello[SpawnRate.Lv+1].Cost;
            txtTotPoints.text = playerInst.TotalPoints.ToString("0");
            SpawnRate.Lv++;
            GameSingleton.instance.SpawnRateSeconds = SpawnRate.livello[SpawnRate.Lv].Value;
            PlayerPrefs.SetInt("SpawnRate", SpawnRate.Lv);
            ChangeSpawnTexts();
        }
    }
}
