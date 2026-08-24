using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Torreta : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Transform pontoDeRotacaoDaTorreta;
    [SerializeField] private LayerMask Emascara;
    [SerializeField] private GameObject PrefabBala;
    [SerializeField] private Transform PontaDaArma;

    [Header("Atributos")]
    [SerializeField] private float Range = 5f;
    [SerializeField] private float velRotacao = 5f;
    [SerializeField] private float BalasPorSec = 1f;
    [SerializeField] private float Dano = 1;
    [SerializeField] private int precoUpgradeBase = 100;
    

    private float RangeBase;
    private float DanoBase;
    private float BalasPorSecBase;

    private Button botaoUpgrade;
    private GameObject upgradeUI;
    private GameObject EscolherUI;
    private TextMeshProUGUI upgradeTXT;

    


    private Transform Alvo = null;
    private float cooldown;
    private int lvl = 1;


    void Start()
    {
        RangeBase = Range;
        DanoBase = Dano;
        BalasPorSecBase = BalasPorSec;
        Menus menuAUsar = MenuManager.main.GetMenuSelecionado();
        upgradeUI = menuAUsar.upgradeUI;
        upgradeTXT = menuAUsar.upgradeTXT;
        EscolherUI = menuAUsar.CompraUI;
        botaoUpgrade = menuAUsar.upgradeBTN;
        AtivarUIUpgrade();
        botaoUpgrade.onClick.AddListener(Upgrade);
        upgradeTXT.SetText("Upgrade : " + precoUpgradeBase);
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
        GameObject balaobj = Instantiate(PrefabBala, PontaDaArma.position, Quaternion.identity);
        Bala balacodigo = balaobj.GetComponent<Bala>();
        balacodigo.MarcarAlvo(Alvo);
        balacodigo.PegarValorDano(Mathf.RoundToInt(Dano));
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
        pontoDeRotacaoDaTorreta.rotation = Quaternion.RotateTowards(pontoDeRotacaoDaTorreta.rotation, RotacaoAlvo, velRotacao * Time.deltaTime);
    }

    public void AtivarUIUpgrade()
    {
        upgradeUI.SetActive(true);
        EscolherUI.SetActive(false);
    }
    public void DesativarUpgradeUI()
    {
        upgradeUI.SetActive(false);
        EscolherUI.SetActive(true);
    }
   
    public void Upgrade()
    {
        if (CalcularCusto() > manager.main.moedas) return;
        manager.main.gastarDinheiro(CalcularCusto());

        BalasPorSec = CalcularBPS();
        Range = CalcularRange();
        Dano = CalcularDano();
        lvl++;
        upgradeTXT.SetText("Upgrade : " + CalcularCusto());

    }
    private int CalcularCusto()
    {
        return Mathf.RoundToInt(precoUpgradeBase * Mathf.Pow(lvl, 0.8f));
    }
    private float CalcularBPS()
    {
        return (BalasPorSecBase * Mathf.Pow(lvl, 0.5f));
    }
    private float CalcularRange()
    {
        return (RangeBase * Mathf.Pow(lvl, 0.5f));
    }
    private float CalcularDano()
    {
        return (DanoBase * Mathf.Pow(lvl, 0.5f));
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, Range);
    }
}
