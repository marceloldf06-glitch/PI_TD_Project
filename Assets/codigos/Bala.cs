using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Rigidbody2D rb;


    [Header("Atributos")]
    [SerializeField] private float VelBala = 5f;
    private int DanoDaBala;

    private Transform Alvo;

    public void PegarValorDano (int _dano)
    {
        DanoDaBala = _dano;
    }
    public void MarcarAlvo(Transform _alvo)
    {
        Alvo = _alvo;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {

        if (!Alvo) {

            espera(5);
            Destroy(gameObject);
            return; 
        }
        Vector2 direcao = (Alvo.position - transform.position).normalized;

        rb.velocity = direcao * VelBala;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Inimigo>().LevarDano(DanoDaBala);
        Destroy(gameObject);
    }

    private IEnumerator espera(int _t)
    {
        yield return new WaitForSecondsRealtime(_t);
    }

}
