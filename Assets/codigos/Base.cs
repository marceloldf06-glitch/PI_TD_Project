using System;
using UnityEngine;

[Serializable]
public class Base {

    public String nome;
    public int custo;
    public GameObject prefab;

    public Base (String _nome, int _custo, GameObject _prefab){
        nome = _nome;
        custo = _custo;
        prefab = _prefab;
        }




}
