using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fasemanager : MonoBehaviour
{
    private int fase;
    [SerializeField] private GameObject[] fases;
    [SerializeField] private Sprite[] fasessprites;
    private void Start()
    {
        fase = fasesliberadas.Instance.fasecompletada;
        for (int i = 0; i < fases.Length; i++)
        {
            if(i < fase)
            {
                fases[i].GetComponent<SpriteRenderer>().sprite = fasessprites[0];
                fases[i].GetComponent<lvlloader>().fase = -1;
            }
            else if(i == fase){
                fases[i].GetComponent<SpriteRenderer>().sprite = fasessprites[1];
                fases[i].GetComponent<lvlloader>().fase = this.fase +2;
            }
            else if(i > fase)
            {
                fases[i].GetComponent<SpriteRenderer>().sprite = fasessprites[2];
                fases[i].GetComponent<lvlloader>().fase = -1;
            } 
        }
    }
}
