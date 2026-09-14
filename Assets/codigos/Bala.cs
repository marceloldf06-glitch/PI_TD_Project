using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Bala : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Rigidbody2D rb;


    [Header("Atributos")]
    [SerializeField] private float VelBala = 5f;

    private int DanoDaBala;
    private int pierce = 0;
    private int slow = 0;
    private int ricochete = 0;
    private int p = 0;
    private float dotdmg;
    private float dotdur;
    private float back;
    private Transform Alvo;

    public void PegarValorDano (int _dano)
    {
        DanoDaBala = _dano;
    }

    public void pegarPierce(int _pierce)
    {
        pierce = _pierce;
    }
    public void pegarSlow(int _slow)
    {
        slow = _slow;
    }
    public void pegarRicochete(int _ricochete)
    {
        ricochete = _ricochete;
    }

    public void MarcarAlvo(Transform _alvo)
    {
        Alvo = _alvo;
    }
    public void pegardot(float _dotdmg, float _dotdur)
    {
        dotdmg = _dotdmg;dotdur = _dotdur;
    }
    public void pegarback(float _back)
    {
        back = _back;

    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (!Alvo) {
            StartCoroutine(espera(5));
            return;
        }
        Vector2 direcao = (Alvo.position - transform.position).normalized;

        rb.velocity = direcao * VelBala;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (ricochete > pierce)
        {
            pierce += ricochete;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Inimigo>().LevarDano(DanoDaBala);
        collision.gameObject.GetComponent<Inimigo>().LevarDot(dotdmg, dotdur);
        collision.gameObject.GetComponent<EMover>().Slow(slow);
        collision.gameObject.GetComponent<EMover>().back(back);
        Alvo = null;

        p++;
        if (p >= (pierce+1))
        {
            Destroy(gameObject);
        }

    }

    private IEnumerator espera(int _t)
    {
        yield return new WaitForSecondsRealtime(_t);
        Destroy(gameObject);
    }
}
