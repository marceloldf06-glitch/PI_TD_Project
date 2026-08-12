using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Transform pontoDeRotacaoDaTorreta;
    [SerializeField] private LayerMask Emascara;
    [SerializeField] private GameObject PrefabBala;
    [SerializeField] private Transform PontoDeAcerto;

    [Header("Atributos")]
    [SerializeField] private float Range = 5f;
    [SerializeField] private float velRotacao = 5f;
    [SerializeField] private float BalasPorSec = 1f;
    [SerializeField] private int Dano = 1;

    private Transform Alvo = null;
    private float cooldown;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Alvo == null)
        {
            AcharAlvo();
            return;
        }
        RotacionarAteAlvo();
        if (!ChecarAlvoEmRange())
        {
            Alvo = null;    
        }
        else
        {
            cooldown += Time.deltaTime;
            if(cooldown >= 1f/BalasPorSec)
            {
                Atirar(); 
                cooldown = 0f;
            }
        }


    }

    private void Atirar()
    {
        GameObject balaobj = Instantiate(PrefabBala, PontoDeAcerto.position, Quaternion.identity);
        Bala balacodigo = balaobj.GetComponent<Bala>();
        balacodigo.MarcarAlvo(Alvo);
        balacodigo.PegarValorDano(Dano);
    }
    private void AcharAlvo()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, Range, (Vector2)transform.position, 0f, Emascara);

        if (hits.Length > 0)
        {
            Alvo = hits[0].transform;
        }
    }
    private bool ChecarAlvoEmRange()
    {
        return Vector2.Distance(Alvo.position, transform.position) <= Range;
    }
    private void RotacionarAteAlvo()
    {
        float angulo = Mathf.Atan2(Alvo.position.y - transform.position.y,
        Alvo.position.x - transform.position.x) * Mathf.Rad2Deg - 90f ;

        Quaternion RotacaoAlvo = Quaternion.Euler(new Vector3(0f, 0f, angulo));
        pontoDeRotacaoDaTorreta.rotation = 
        Quaternion.RotateTowards(pontoDeRotacaoDaTorreta.rotation, 
        RotacaoAlvo, velRotacao * Time.deltaTime);
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, Range);
    }
}
