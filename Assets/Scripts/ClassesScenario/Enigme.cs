using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enigme
{
    private string name;
    private int num;
    private int[] suite;
    private float temps;

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
