using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class manager : MonoBehaviour
{
    public static manager main;

    public Transform SP;
    public Transform[] caminho;
    public Transform EP;

    public int vida = 10;

    public int moedas;
    public int moedas_iniciais = 100;
    public int baus = 0;
    private void Update()
    {
        if(vida <= 0 )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        moedas = moedas_iniciais;
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
