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
    public int pierce;
    public int slow;
    public float knockback;
    public float dotDMG;
    public float dotDur;




    public TorretaStatus(float _velAttk, float _Dano, float _Range, float _Preco, float _critChance, float _critDMG, float _dotDMG, float _dotDur, int _slow, float _knockback)
    {
        velAttk = _velAttk;
        Dano = _Dano;
        Range = _Range;
        Preco = _Preco;
        critChance = _critChance;
        critDMG = _critDMG;
        dotDMG = _dotDMG;
        dotDur = _dotDur;
        slow = _slow;
        knockback = _knockback;

    }




}