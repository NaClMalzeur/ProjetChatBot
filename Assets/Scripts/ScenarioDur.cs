using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioDur : MonoBehaviour
{

    Enigme[] enigmes = new Enigme[11]
    {
        new Enigme("L",1,new int[1] {0},5.0f),
        new Enigme("Losange",2,new int[1] {1},6.3f),
        new Enigme("Carre",3,new int[1] {2},8.0f),
        new Enigme("Sablier",4,new int[1] {3},3.0f),
        new Enigme("Triangle",5,new int[1] {4},5.0f),
        new Enigme("Rond",6,new int[1] {5},10.0f),
        new Enigme("Lune",7,new int[1] {6},12.30f),
        new Enigme("Croix",8,new int[1] {7},11.0f),
        new Enigme("Etoile",9,new int[1] {8},11.0f),
        new Enigme("Y",10,new int[1] {9},5.0f),
        new Enigme("Hexagone",11,new int[1] {10},8.0f)
    };

    Indice[] indices = new Indice[33]
    {
        new Indice("L","L_1.jpg","",1),
        new Indice("L","L_2.jpg","",2),
        new Indice("L","L_3.jpg","",3),
        new Indice("Losange","Losange_1.jpg","",1),
        new Indice("Losange","Losange_2.jpg","",2),
        new Indice("Losange","Losange_3.jpg","",3),
        new Indice("Carre","Carre_1.jpg","",1),
        new Indice("Carre","Carre_2.jpg","",2),
        new Indice("Carre","Carre_3.jpg","",3),
        new Indice("Sablier","Sablier_1.jpg","",1),
        new Indice("Sablier","Sablier_2.jpg","",2),
        new Indice("Sablier","Sablier_3.jpg","",3),
        new Indice("Triangle","Triangle_1.jpg","",1),
        new Indice("Triangle","Triangle_2.jpg","",2),
        new Indice("Triangle","Triangle_3.jpg","",3),
        new Indice("Rond","Rond_1.jpg","",1),
        new Indice("Rond","Rond_2.jpg","",2),
        new Indice("Rond","Rond_3.jpg","",3),
        new Indice("Lune","Lune_1.jpg","",1),
        new Indice("Lune","Lune_2.jpg","",2),
        new Indice("Lune","Lune_3.jpg","",3),
        new Indice("Croix","Croix_1.jpg","",1),
        new Indice("Croix","Croix_2.jpg","",2),
        new Indice("Croix","Croix_3.jpg","",3),
        new Indice("Etoile","Etoile_1.jpg","",1),
        new Indice("Etoile","Etoile_2.jpg","",2),
        new Indice("Etoile","Etoile_3.jpg","",3),
        new Indice("Y","Y_1.jpg","",1),
        new Indice("Y","Y_2.jpg","",2),
        new Indice("Y","Y_3.jpg","",3),
        new Indice("Hexagone","Hexagone_1.jpg","",1),
        new Indice("Hexagone","Hexagone_2.jpg","",2),
        new Indice("Hexagone","Hexagone_3.jpg","",3)
    };

}
