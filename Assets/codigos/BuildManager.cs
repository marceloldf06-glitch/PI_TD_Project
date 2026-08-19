using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("Referencias")]
    [SerializeField] private Base[] torres;

    private int torreselecionada = -1;

    private void Awake()
    {
        main = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Base GetTorreSelecionada()
    {
        return torres[torreselecionada];
    }

    public void  SetTorreSelecionada(int _torreSelecionada)
    {
        torreselecionada = _torreSelecionada;
    }

}
