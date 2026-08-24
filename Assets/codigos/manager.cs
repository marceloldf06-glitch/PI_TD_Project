using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class manager : MonoBehaviour
{
    public static manager main;

    public Transform SP;
    public Transform[] caminho;
    public Transform EP;

    public int vida = 10;

    public int moedas;

    private void Update()
    {
        if(vida <= 0 )
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        moedas = 100;
    }

    public void levarDano(int dano)
    {
        vida -= dano;
    }

    public void ganharDinheiro(int quantidade)
    {
        moedas += quantidade;
    }
    public bool gastarDinheiro(int quantidade)
    {
        if (quantidade <= moedas)
        {
            moedas -= quantidade;
            return true;
        }
        else
        {
            return false;
        }
    }
}
