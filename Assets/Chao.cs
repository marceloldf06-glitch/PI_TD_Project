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

    // Update is called once per frame
    void Update()
    {
        
    }
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
        if (torre == null) return;
        GameObject torreAContruir = BuildManager.main.GetTorreSelecionada();
        torre = Instantiate(torreAContruir, transform.position, Quaternion.identity);
    }
}
