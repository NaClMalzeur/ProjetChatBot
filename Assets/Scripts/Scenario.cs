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

    public static Scenario CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Scenario>(jsonString);
    }

    public static Scenario CreateFromFile(string file)
    {
        string jsonString = "";
        try 
        {
            using (StreamReader sr = new StreamReader(file)) 
            {
                string line;
                while ((line = sr.ReadLine()) != null) 
                {
                    jsonString += "\n" + line;
                    Debug.Log(line);
                }
            }
        }
        catch (Exception e) 
        {
            Debug.Log("The file could not be read:");
             Debug.Log(e.Message);
        }
        return CreateFromJSON(jsonString);
    }

}
