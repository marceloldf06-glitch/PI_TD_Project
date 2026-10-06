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
    public ItemBuff[] items;

    public void pegarbuff(Sprite spritebuff)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (spritebuff == items[i].spriteitem) {
                velAttk += items[i].velAttk;
                Dano += items[i].Dano;
                Range += items[i].Range;
                critChance += items[i].critChance;
                critDMG += items[i].critDMG;
                pierce += items[i].pierce;
                slow += items[i].slow;
                knockback += items[i].knockback;
                dotDMG += items[i].dotDMG;
                dotDur += items[i].dotDur;
            }
        }
        
    }



}
