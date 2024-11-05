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
    public GameObject menu; 
    public GameObject Credits;

    public void Start(){
        //fa vedere il menu con tutti i suoi figli e nasconde la schermata dei crediti
        menu.SetActive(true);
        Credits.SetActive(false);
    }

    //public void nomeMetodo() -> andrà poi assegnato al pulsante di riferimento
    public void UI_Start(){
        HideAll();
        SceneManager.LoadScene("Bosco");
    }

    public void UI_Credits(){
        menu.SetActive(false);
        Credits.SetActive(true);
    }

    public void UI_Back(){
        menu.SetActive(true);
        Credits.SetActive(false);
    }

    public void UI_Quit(){
        Application.Quit();
    }

    public void HideAll(){
        menu.SetActive(false);
        Credits.SetActive(false);
    }
    
}
