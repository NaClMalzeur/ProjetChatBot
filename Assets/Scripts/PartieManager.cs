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


    // Update is called once per frame
    void Update()
    {
        
    }
}
