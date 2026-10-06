using System;
using UnityEngine;

[Serializable]
public class ItemBuff
{
    public Sprite spriteitem;
    public float velAttk;
    public float Dano;
    public float Range;
    public float critChance;
    public float critDMG;
    public int pierce;
    public int slow;
    public float knockback;
    public float dotDMG;
    public float dotDur;
    
    public ItemBuff(float _velAttk, float _Dano, float _Range, float _critChance, float _critDMG, int _pierce, int _slow, float _knockback, float _dotDMG, float _dotDur)
    {
        velAttk = _velAttk;
        Dano = _Dano;
        Range = _Range;
        critChance = _critChance;
        critDMG = _critDMG;
        pierce = _pierce;
        slow = _slow;
        knockback = _knockback;
        dotDMG = _dotDMG;
        dotDur = _dotDur;
    }
}
