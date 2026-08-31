using System;
using UnityEngine;

[Serializable]
public class TorretaStatus
{

    public float velAttk;
    public float Dano;
    public float Range;
    public float Preco;
    public TorretaStatus(float _velAttk, float _Dano, float _Range, float _Preco)
    {
        velAttk = _velAttk;
        Dano = _Dano;
        Range = _Range;
        Preco = _Preco;
    }




}