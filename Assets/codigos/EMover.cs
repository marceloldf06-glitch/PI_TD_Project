using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMover : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Atributos")]
    [SerializeField] private float velocidade = 2f;

    private Transform alvo;
    private int indexcaminho = 0;

    private void Start()
    {
        alvo = manager.main.caminho[indexcaminho];
    }
    private void Update()
    {
        if (Vector2.Distance(alvo.position, transform.position) <= 0.1f)
        {
            indexcaminho++;


            if (indexcaminho == manager.main.caminho.Length)
            {
                ESpawner.emEDestruido.Invoke();
                Destroy(gameObject);
                manager.main.levarDano(1);
                return;
            }
            else
            {
                alvo = manager.main.caminho[indexcaminho];
            }
            }
        
    }
    public void Slow(int _slow)
    {
        velocidade -= ((velocidade / 100) * _slow);
    }
    private void FixedUpdate()
    {
       Vector2 direcao = (alvo.position - transform.position).normalized;

        rb.velocity = direcao * velocidade;
    }

}
