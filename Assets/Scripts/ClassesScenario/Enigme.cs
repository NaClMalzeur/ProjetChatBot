using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enigme
{
    public string name;
    public int num;
    public int[] suite;
    public float temps;

    public Enigme(string name, int num, int[] suite, float temps)
    {
        this.name = name;
        this.num = num;
        this.suite = suite;
        this.temps = temps;
    }

    public static Enigme CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Enigme>(jsonString);
    }
}
