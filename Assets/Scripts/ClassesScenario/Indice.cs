using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Indice
{
    private string enigme, image, description;
    private int rang;

    public Indice(string enigme, string image, string description, int rang)
    {
        this.enigme = enigme;
        this.image = image;
        this.description = description;
        this.rang = rang;
    }

    public static Indice CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Indice>(jsonString);
    }
}
