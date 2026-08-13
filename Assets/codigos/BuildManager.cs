using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("Referencias")]
    [SerializeField] private GameObject[] prefabtorres;

    private int torreselecionada = 0;

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

    public GameObject GetTorreSelecionada()
    {
        return prefabtorres[torreselecionada];
    }
}
