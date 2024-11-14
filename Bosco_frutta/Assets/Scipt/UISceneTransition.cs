using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UISceneTransition : MonoBehaviour
{

    // nome del parent che contiene tutte le info del menu (testi, pulsanti, ecc...)
    // nell'inspector unity assegni oggetto null genitore menu
    public GameObject Menu; 
    public GameObject Crediti;
    public GameObject Opzioni;
    public GameObject GameEsc;

    public void Start(){
        //fa vedere il menu con tutti i suoi figli e nasconde la schermata dei crediti
        Menu.SetActive(true);
        Crediti.SetActive(false);
        Opzioni.SetActive(false);
        GameEsc.SetActive(false);
        AudioManager.instance.Play("Cabin_Bg");
        AudioManager.instance.Play("fireplace");
    }

    //public void nomeMetodo() -> andrà poi assegnato al pulsante di riferimento
    public void UI_Start(){
        HideAll();
        AudioManager.instance.Stop("Cabin_Bg");
        AudioManager.instance.Stop("fireplace");
        SceneManager.LoadScene("Bosco");
    }

    public void UI_Credits(){
        Menu.SetActive(false);
        Crediti.SetActive(true);
    }

    public void UI_Options(){
        Menu.SetActive(false);
        Opzioni.SetActive(true);
    }

    public void UI_GameEsc(){
        Menu.SetActive(false);
        GameEsc.SetActive(true);
    }

    public void UI_Back(){
        Menu.SetActive(true);
        Crediti.SetActive(false);
        Opzioni.SetActive(false);
        GameEsc.SetActive(false);
    }
    
    public void GameReset(){

    }

    public void HideAll(){
        Menu.SetActive(false);
        Crediti.SetActive(false);
        Opzioni.SetActive(false);
        GameEsc.SetActive(false);
    }
    
}
