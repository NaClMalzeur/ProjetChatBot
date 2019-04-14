using UnityEngine;
using System;
using System.IO;

/**
    Objet conteneur des informations du scénario
*/
[System.Serializable]
public class Scenario
{

    private Enigme[] enigmes;
    private Indice[] indices;

    public Scenario(Enigme[] enigmes, Indice[] indices)
    {
        this.enigmes = enigmes;
        this.indices = indices;
    }

}
