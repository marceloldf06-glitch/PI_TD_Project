using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GlobalBuffManager : MonoBehaviour
{
    public static GlobalBuffManager main;

    private void Awake()
    {
        main = this;
    }
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

    public void pegarbuff(ItemBuff spritebuff)
    {
        velAttk += spritebuff.velAttk;
        Dano += spritebuff.Dano;
        Range += spritebuff.Range;
        critChance += spritebuff.critChance;
        critDMG += spritebuff.critDMG;
        pierce += spritebuff.pierce;
        slow += spritebuff.slow;
        knockback += spritebuff.knockback;
        dotDMG += spritebuff.dotDMG;
        dotDur += spritebuff.dotDur;
    }



}
