using System;
using UnityEngine;

[Serializable]
public class TorretaStatus
{

    public float velAttk;
    public float Dano;
    public float Range;
    public float Preco;
    public float critChance;
    public float critDMG;
    public TorretaStatus(float _velAttk, float _Dano, float _Range, float _Preco, float _critChance, float _critDMG)
    {
        velAttk = _velAttk;
        Dano = _Dano;
        Range = _Range;
        Preco = _Preco;
        critChance = _critChance;
        critDMG = _critDMG;
    }




}