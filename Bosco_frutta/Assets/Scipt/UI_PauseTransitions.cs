using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UI_PauseTransitions : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Opzioni;
    public GameObject Menu;
    public GameObject PauseCanvas;

    //far spawnare canvas quando premi trigger button mano sx
    public InputActionProperty showButton;
    public Transform head;
    public float spawnDistance = 2;
    bool Pause;

    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(false);
        Opzioni.SetActive(false);
        Menu.SetActive(false);
        PauseCanvas.SetActive(false);
        Pause = false;
        Debug.Log(showButton);
    }

    void Update(){
        
        if(showButton.action.WasPressedThisFrame()){
            Debug.Log("Bottone premuto");
            if(!Pause){
                PauseCanvas.SetActive(true);
                PauseCanvas.transform.position = head.position + new Vector3 (head.forward.x, 0, head.forward.z).normalized * spawnDistance;
                // Time.timeScale = 0; disattiva il movimento giocatore e ferma il tempo
                Time.timeScale = 0;
                Pause = true;
            }
        }

    }

    public void UI_resume(){
        PauseCanvas.SetActive(false);
        // Time.timeScale = 1; riattiva movimento e tempo;
        Time.timeScale = 1;
        Pause = false;
    }

    // Update is called once per frame
    public void UI_Back(){
        MainMenu.SetActive(true);
        Opzioni.SetActive(false);
        Menu.SetActive(false);
    }

    public void UI_Options(){
        MainMenu.SetActive(false);
        Opzioni.SetActive(true);
    }

    public void UI_Menu(){
        MainMenu.SetActive(false);
        Menu.SetActive(true);
    }

    public void UI_ReturnMenu(){
        HideAll();
        SceneManager.LoadScene("Stanza");
    }

    public void HideAll(){
        MainMenu.SetActive(false);
        Menu.SetActive(false);
        Opzioni.SetActive(false);
    }
}
