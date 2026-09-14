using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EMover : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Atributos")]
    [SerializeField] private float velocidade = 2f;

    private Transform alvo;
    private int indexcaminho = 0;
    private float vel;

    private void Start()
    {
        vel = velocidade;
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
        velocidade = ((vel / 100) * _slow);
    }
    public void back(float _back)
    {
        velocidade = 0f;
        StartCoroutine(bkt(_back));
        
    }
    private void FixedUpdate()
    {
       Vector2 direcao = (alvo.position - transform.position).normalized;

        rb.velocity = direcao * velocidade;
    }
    private IEnumerator bkt(float _t)
    { 
        yield return new WaitForSecondsRealtime(_t);
        velocidade = vel;
    }
}
