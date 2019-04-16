using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    Classes contenant les méthodes statics d'entrées / sorties
    de l'application
    - Charger un scénario
    - Ecrire logs
 */
public class IO 
{


    /*
        Charge le scénario décrit dans le fichier donné
        Créer un objet contenant les différentes informations du scénario
        comme l'ordonnancement énigmes / indices
        statisques
        paramètres propre au scénario (UI + effets) 
     */
    public static Scenario LoadScenario(string filename) {

        return null; // STUB
    }


    public static Sprite GetIndiceSprite(Indice indice) {

        if (indice.sprite == null) {
            Debug.Log("GetIndiceSprite : " + indice.enigme + " " + indice.rang + " first load : " + indice.image);

            if (Resources.Load<Sprite>("Sprites/" + indice.image) == null) {
                Debug.Log("OSCOUR");
            }

            indice.sprite = Resources.Load<Sprite>("Sprites/" + indice.image);
        }

        return indice.sprite;
    }


}
