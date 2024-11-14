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
        Pause = false;
    }

    void Update(){
        
        if(showButton.action.WasPressedThisFrame()){
            if(!Pause){
                MainMenu.SetActive(true);
                
                //MainMenu
                MainMenu.transform.position = head.position + new Vector3 (head.forward.x, 0, head.forward.z).normalized * spawnDistance;
                MainMenu.transform.LookAt(new Vector3(head.position.x, MainMenu.transform.position.y, head.position.z));
                MainMenu.transform.forward *= -1;

                //Opzioni
                Opzioni.transform.position = head.position + new Vector3 (head.forward.x, 0, head.forward.z).normalized * spawnDistance;
                Opzioni.transform.LookAt(new Vector3(head.position.x, Opzioni.transform.position.y, head.position.z));
                Opzioni.transform.forward *= -1;

                //Menu
                Menu.transform.position = head.position + new Vector3 (head.forward.x, 0, head.forward.z).normalized * spawnDistance;
                Menu.transform.LookAt(new Vector3(head.position.x, Menu.transform.position.y, head.position.z));
                Menu.transform.forward *= -1;

                // Time.timeScale = 0; disattiva il movimento giocatore e ferma il tempo
                Time.timeScale = 0;
                Pause = true;
            }
        }

    }

    public void UI_resume(){
        MainMenu.SetActive(false);        
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
        Time.timeScale = 1;
        AudioManager.instance.Stop("Forest_ambient");
        AudioManager.instance.Stop("Forest_BG");
        SceneManager.LoadScene("Stanza");
    }

    public void HideAll(){
        MainMenu.SetActive(false);
        Menu.SetActive(false);
        Opzioni.SetActive(false);
    }
}
