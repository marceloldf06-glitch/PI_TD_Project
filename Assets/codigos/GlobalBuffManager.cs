using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    private string desc = "Atributos:";

    public void pegarbuff(Sprite sprite_buff)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (sprite_buff == items[i].spriteitem) {
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
    public string description(Sprite sprite_item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (sprite_item == items[i].spriteitem)
            {
                if(items[i].velAttk > 0 || items[i].velAttk < 0)
                {
                    desc += "\nVelocidade de ataque: " + items[i].velAttk;
                }
                if (items[i].Dano > 0 || items[i].Dano < 0)
                {
                    desc += "\nDano: " + items[i].Dano;
                }
                if (items[i].Range > 0 || items[i].Range < 0)
                {
                    desc += "\nRange: " + items[i].Range;
                }
                if (items[i].critChance > 0 || items[i].critChance < 0)
                {
                    desc += "\nChance critica: " + items[i].critChance;
                }
                if (items[i].critDMG > 0 || items[i].critDMG < 0)
                {
                    desc += "\nDano critico: " + items[i].critDMG;
                }
                if (items[i].pierce > 0 || items[i].pierce < 0)
                {
                    desc += "\nPerfuração: " + items[i].pierce;
                }
                if (items[i].slow > 0 || items[i].slow < 0)
                {
                    desc += "\nDesaceleração: " + items[i].slow;
                }
                if (items[i].knockback > 0 || items[i].knockback < 0)
                {
                    desc += "\nKnockback: " + items[i].knockback;
                }
                if (items[i].dotDMG > 0 || items[i].dotDMG < 0)
                {
                    desc += "\nDano extra do dot: " + items[i].dotDMG;
                }
                if (items[i].dotDur > 0 || items[i].dotDur < 0)
                {
                    desc += "\nDuração extra do dot: " + items[i].dotDur;
                }
            }
        }
        return desc;
    }



}
