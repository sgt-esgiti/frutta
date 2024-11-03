using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Data;
using UnityEngine.SceneManagement;
public class GameCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtGamePoints;
    [SerializeField] private TextMeshProUGUI txtTime;
    public float TimeLeft;
    public bool TimerOn = false;

    private Player playerInst;
    float CanvasGamePoints;
    // Start is called before the first frame update
    void Start()
    {
        playerInst = GameSingleton.instance.player;
        playerInst.GamePoints = 0f;
        CanvasGamePoints = playerInst.GamePoints;
        txtGamePoints.text = CanvasGamePoints.ToString("0");
        TimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(CanvasGamePoints!=playerInst.GamePoints){
            CanvasGamePoints = playerInst.GamePoints;
            txtGamePoints.text = CanvasGamePoints.ToString("0");
        }
        
        //timer canvas
        if(TimerOn){
            if(TimeLeft > 0f){
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else {
                TimeLeft = 0;
                TimerOn = false;
                //cambia scena e aggiorna punti totali player
                playerInst.AddPointsFinal();
                //SceneManager.LoadScene("Scena Stanza")
            }
        }
    }

    void updateTimer (float currentTime){
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        txtTime.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}