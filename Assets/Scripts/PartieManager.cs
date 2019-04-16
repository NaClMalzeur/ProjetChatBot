using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

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

    public Scenario scenario = ScenarioDur.scenarioDur;
    
    float timePassed = 0f;
    public float timeAvgHint = 10f;

    public float timeHintShowed = 10f;

    public bool isShowingHint;

    public List<Enigme> enigmesDisponibles;
    public List<int> enigmesFaites;

    Enigme enigmeCourante;
    int numIndiceCourant;



    public GameObject btnEnigmeFaitesPrefab;
    public GameObject btnEnigmeDispoPrefab;



    public Image img_indice;

    public Image img_shinning; // l'image montrant l'énigme séléctionnée

    public GameObject list_enigmes_go;

    public Chrono chrono;

    public GameObject panel_partie_in;
    public GameObject panel_partie_perdue;
    public GameObject panel_discussion;


    // Start is called before the first frame update
    void Start()
    {
        // Check if refs have been set
        if (img_indice == null) {
            Debug.LogWarning("PartieManager: la référence sur l'image d'indice est null !");
        }

        /*if (list_enigmes_go == null) {
            Debug.LogWarning("PartieManager: la référence sur la liste d'énigmes est null !");
        }*/

        if (chrono == null) {
            Debug.LogWarning("PartieManager: la référence sur le chronomètre est null !");
        }
        
        chrono.partieManager = this;
        SetPanelVisible(panel_partie_perdue, false);

        numIndiceCourant = 1;

        enigmesFaites.Add(0);
        enigmesFaites.Add(1);
        SetImageIndiceVisibility(false);
        enigmesDisponibles = GetEnigmesDisponibles();

        ClearBtnEnigmes();
        AddEnigmesDispos();
        AddEnigmesFaites();

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


    public void SetImageIndiceVisibility(bool isVisible) {
        img_indice.transform.parent.parent.gameObject.SetActive(isVisible);
        img_shinning.transform.gameObject.SetActive(isVisible);
    }

    public void SetImageIndice(Enigme enigme, int numIndice){

        if (enigme == null) {
            Debug.Log("SetImageIndice: l'énigme est null !");
            return;  
        }

        // Tant que l'indice n'est pas celui de l'énigme et pas le bon numéro d'indice
        int i;
        Debug.Log("SetImageIndice : " + enigme.name);
        for(i = 0; i < scenario.indices.Length && (!scenario.indices[i].enigme.Equals(enigme.name)
            || scenario.indices[i].rang != numIndice); i++)
            ; // EMPTY BODY

        if (i == scenario.indices.Length) {
            Debug.Log("SetImageIndice: aucun indice trouvé !");
            return;
        }
        img_indice.sprite = IO.GetIndiceSprite(scenario.indices[i]);
    }

    public void SetImageShinning(Enigme enigme) {

       Transform[] childs = list_enigmes_go.GetComponentsInChildren<Transform>();
         for(int i = 0; i < childs.Length; i++) {
            if(childs[i] != list_enigmes_go.transform && childs[i].GetComponentInChildren<TextMeshProUGUI>().text == enigme.num.ToString()) {
                img_shinning.transform.position = childs[i].transform.position;
                return;        
            }
        }
    }

    public void ClearBtnEnigmes() {
        Transform[] childs = list_enigmes_go.GetComponentsInChildren<Transform>();
        for(int i = 0; i < childs.Length; i++) {
            if(childs[i] == list_enigmes_go.transform) {
                continue;
            }
            Destroy(childs[i].gameObject);
        }
    }

    public void AddEnigmesFaites() {
        for(int i = 0; i < enigmesFaites.Count; i++) {
            if (enigmesFaites[i] == 0) {
                continue;
            }
            AddBtnEnigme(false, enigmesFaites[i]);
        }
    }

    public void AddEnigmesDispos() {
        for(int i = 0; i < enigmesDisponibles.Count; i++) {
            AddBtnEnigme(true, enigmesDisponibles[i].num);
        }
    }

    public void AddBtnEnigme(bool isDispo, int num) {
        GameObject go;
        
        if (isDispo) {
            go = Instantiate(btnEnigmeDispoPrefab, Vector3.zero, Quaternion.identity, list_enigmes_go.transform);
        } else {
            go = Instantiate(btnEnigmeFaitesPrefab, Vector3.zero, Quaternion.identity, list_enigmes_go.transform);
        }

        go.GetComponentInChildren<TextMeshProUGUI>().text = num.ToString();
    }

    public List<Enigme> GetEnigmesDisponibles() {
        List<Enigme> enigmes = new List<Enigme>();

        for(int i = 0; i < scenario.enigmes.Length; i++) {
            if (enigmesFaites.Contains(scenario.enigmes[i].num)) {
                continue;
            }
            
            int j;
            for(j = 0; j < scenario.enigmes[i].suite.Length
                && enigmesFaites.Contains(scenario.enigmes[i].suite[j]); j++)
                ; // EMPTY BODY

            if (j == scenario.enigmes[i].suite.Length) {
                enigmes.Add(scenario.enigmes[i]);

                AddBtnEnigme(true, scenario.enigmes[i].num);
            }
        }

        return enigmes;
    }

    /*
     propose l'indice le plus proche parmi les métriques
    */
    public void ProposerIndice() {
        Debug.Log("Proposer indice");

        List<Enigme> enigmesProches = GetEnigmesProchesTemps();
        if (enigmesProches.Count > 0) {
            enigmeCourante = enigmesProches[0];
            Debug.Log("ProposerIndice : enigme " + enigmeCourante.name + " choisie" );
            SetImageIndice(enigmeCourante, numIndiceCourant);
            SetImageShinning(enigmeCourante);
            StartCoroutine(WaitBeforeHideHint());
        } else {
            Debug.Log("ProposerIndice : aucune enigme choisie" );
        }
         
    }

    /*
        Retourne la liste des énigmes proches dans l'ordre croissant
     */
    public List<Enigme> GetEnigmesProchesTemps() {
        
        List<Enigme> enigmesProches = new List<Enigme>();

        for(int i = 0; i < enigmesDisponibles.Count; i++) {
            if ( Mathf.Abs(enigmesDisponibles[i].temps - timePassed) < timeAvgHint) {
                int j;
                for(j = 0; j < enigmesProches.Count && 
                    Mathf.Abs(enigmesProches[j].temps - timePassed) < Mathf.Abs(enigmesDisponibles[i].temps - timePassed)
                    ; j++) ; // EMPTY BODY

                enigmesProches.Insert(j, enigmesDisponibles[i]);
            } 
        }
 
        return enigmesProches;
    }

    IEnumerator WaitBeforeHideHint() {
        Debug.Log("WaitBeforeHideHint : start");
        isShowingHint = true;
        SetImageIndiceVisibility(true);
        yield return new WaitForSeconds(timeHintShowed);
        isShowingHint = false;
        SetImageIndiceVisibility(false);
        Debug.Log("WaitBeforeHideHint : end");
    }


    public void AccepterIndice() {
        SetPanelVisible(panel_partie_in, false);
        SetPanelVisible(panel_discussion, true);
    }


    public void DemanderIndice() {
        /*List<> enigmesProches =  */GetEnigmesProchesMetrics();

        // Récupère les énigmes proches 
        // Affiche le panel de discussion
        // Demande quelle énigme est la bonne parmi la liste
        // Quand trouvé, propose indice
        

    }

    /* List<> */ public void GetEnigmesProchesMetrics() {
        Debug.Log("Liste des indices les plus probables");
        // return list;
    }



    // Update is called once per frame
    void LateUpdate()
    {
        // Update le temps passé
        timePassed += Time.deltaTime;

        if (!isShowingHint) {
            ProposerIndice();
        }

        // Si proche d'une demande d'indice, propose un indice de cette énigme
        /* Indice indice_propose = */ 

    }
}
