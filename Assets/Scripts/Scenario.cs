using UnityEngine;
using System;
using System.IO;

/**
    Objet conteneur des informations du scénario
*/
[System.Serializable]
public class Scenario
{ 
    public Enigme[] enigmes;
    public Indice[] indices;

    public Scenario(Enigme[] enigmes, Indice[] indices)
    {
        this.enigmes = enigmes;
        this.indices = indices;
    }

}
