using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

/**
    Classe permettant les interactions du joueur durant la partie
    - Demande d'indice
    - Proposition d'indice
    - Gestion UI
    - Affichage chatbot
    etc
 */
public class PartieManager : MonoBehaviour
{

    public Image img_indice;

    public Image selected_img; // l'image montrant l'énigme séléctionnée

    public GameObject list_enigmes_go;

    public Chrono chrono;

    public GameObject panel_partie_perdue;


    // Start is called before the first frame update
    void Start()
    {
        // Check if refs have been set
        if (img_indice == null) {
            Debug.LogWarning("PartieManager: la référence sur l'image d'indice est null !");
        }
        if (list_enigmes_go == null) {
            Debug.LogWarning("PartieManager: la référence sur la liste d'énigmes est null !");
        }

        if (chrono == null) {
            Debug.LogWarning("PartieManager: la référence sur le chronomètre est null !");
        }
        
        chrono.partieManager = this;
        SetPanelVisible(panel_partie_perdue, false);
    }

    public void ShowPanelGameOver() {
        Debug.Log("Partie Finie");

        SetPanelVisible(panel_partie_perdue, true);
    }

    public void SetPanelVisible(GameObject panel, bool isVisible) {
        CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup>();

        if (canvasGroup == null) {
            Debug.LogWarning("PartieManager: canvasGroup de " + panel.name +  " est null !");
            return;
        }

        canvasGroup.alpha = isVisible ? 1 : 0;
        canvasGroup.interactable = isVisible;
        canvasGroup.blocksRaycasts = isVisible;
    }
    /*
     propose l'indice le plus proche parmi les métriques
    */
    /* Indice */ public void ProposerIndice() {
        Debug.Log("Proposer indice");
        // return indice;
    }


    public void DemanderIndice() {
        /*List<> enigmesProches =  */GetEnigmesProches();

        // Récupère les énigmes proches 
        // Affiche le panel de discussion
        // Demande quelle énigme est la bonne parmi la liste
        // Quand trouvé, propose indice
        

    }

    /* List<> */ public void GetEnigmesProches() {
        Debug.Log("Liste des indices les plus probables");
        // return list;
    }



    // Update is called once per frame
    void LateUpdate()
    {

        // Si proche d'une demande d'indice, propose un indice de cette énigme
        /* Indice indice_propose = */ 

    }
}
