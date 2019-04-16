using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioDur : MonoBehaviour
{    
    public static Enigme[] enigmes = new Enigme[11]
    {
        new Enigme("L",1,new int[] {0},5.0f),
        new Enigme("Losange",2,new int[] {1},6.3f),
        new Enigme("Carre",3,new int[] {2},8.0f),
        new Enigme("Sablier",4,new int[] {3},3.0f),
        new Enigme("Triangle",5,new int[] {4},5.0f),
        new Enigme("Rond",6,new int[] {5},10.0f),
        new Enigme("Lune",7,new int[] {6},12.30f),
        new Enigme("Croix",8,new int[] {7},11.0f),
        new Enigme("Etoile",9,new int[] {8},11.0f),
        new Enigme("Y",10,new int[] {9},5.0f),
        new Enigme("Hexagone",11,new int[] {10},8.0f)
    };

    public static Indice[] indices = new Indice[33]
    {
        new Indice("L","L_1","",1),
        new Indice("L","L_2","",2),
        new Indice("L","L_3","",3),
        new Indice("Losange","Losange_1","",1),
        new Indice("Losange","Losange_2","",2),
        new Indice("Losange","Losange_3","",3),
        new Indice("Carre","Carre_1","",1),
        new Indice("Carre","Carre_2","",2),
        new Indice("Carre","Carre_3","",3),
        new Indice("Sablier","Sablier_1","",1),
        new Indice("Sablier","Sablier_2","",2),
        new Indice("Sablier","Sablier_3","",3),
        new Indice("Triangle","Triangle_1","",1),
        new Indice("Triangle","Triangle_2","",2),
        new Indice("Triangle","Triangle_3","",3),
        new Indice("Rond","Rond_1","",1),
        new Indice("Rond","Rond_2","",2),
        new Indice("Rond","Rond_3","",3),
        new Indice("Lune","Lune_1","",1),
        new Indice("Lune","Lune_2","",2),
        new Indice("Lune","Lune_3","",3),
        new Indice("Croix","Croix_1","",1),
        new Indice("Croix","Croix_2","",2),
        new Indice("Croix","Croix_3","",3),
        new Indice("Etoile","Etoile_1","",1),
        new Indice("Etoile","Etoile_2","",2),
        new Indice("Etoile","Etoile_3","",3),
        new Indice("Y","Y_1","",1),
        new Indice("Y","Y_2","",2),
        new Indice("Y","Y_3","",3),
        new Indice("Hexagone","Hexagone_1","",1),
        new Indice("Hexagone","Hexagone_2","",2),
        new Indice("Hexagone","Hexagone_3","",3)
    };

    public static Scenario scenarioDur = new Scenario(enigmes, indices);
}
