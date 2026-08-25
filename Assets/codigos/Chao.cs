using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chao : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeReference] private SpriteRenderer sr;
    [SerializeField] private Color cor;
    [SerializeField] private Color corVenda;

    private GameObject torreObj;
    public Torreta torreta;
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
        if (torreObj != null)
        {
            
            return;
        }
        Base torreAContruir = BuildManager.main.GetTorreSelecionada();

        if(torreAContruir.custo > manager.main.moedas)
        {
            return;
        }
            
            manager.main.gastarDinheiro(torreAContruir.custo);
            torreObj = Instantiate(torreAContruir.prefab, transform.position, Quaternion.identity);
            torreta = torreObj.GetComponent<Torreta>();
            BuildManager.main.SetTorreSelecionada(-1);
            torreta.transform.position = new Vector3(torreta.transform.position.x, torreta.transform.position.y, -1);
        
    }
}
