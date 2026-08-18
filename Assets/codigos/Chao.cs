using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chao : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeReference] private SpriteRenderer sr;
    [SerializeField] private Color cor;

    private GameObject torre;
    private Color corinicial;
    // Start is called before the first frame update
    void Start()
    {
        corinicial = sr.color;
    }

    // Update is called once per fram
    private void OnMouseEnter()
    {
        sr.color = cor;
    }
    private void OnMouseExit()
    {
        sr.color = corinicial;
    }
    private void OnMouseDown()
    {
        if (torre != null) return;

        Base torreAContruir = BuildManager.main.GetTorreSelecionada();

        if(torreAContruir.custo > manager.main.moedas)
        {
            return;
        }
        manager.main.gastarDinheiro(torreAContruir.custo);
        torre = Instantiate(torreAContruir.prefab, transform.position, Quaternion.identity);
    }
}
