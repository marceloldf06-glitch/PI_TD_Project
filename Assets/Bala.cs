using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private GameObject PrefabBala;
    [SerializeField] private Rigidbody2D rb;


    [Header("Atributos")]
    [SerializeField] private float VelBala = 5f;

    private Transform Alvo;

    public void MarcarAlvo()
    {

    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direcao = (Alvo.position - transform.position).normalized;

        rb.velocity = direcao * VelBala;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
