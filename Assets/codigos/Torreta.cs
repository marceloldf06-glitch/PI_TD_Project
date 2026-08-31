using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    [SerializeField] private TorretaStatus[] Levels;
    
    [SerializeField] private float velRotacao = 5f;



    


    private float BalasPorSec;
    private float Dano;
    private int precoUpgradeBase;
    private float Range;

    private Button botaoUpgrade;
    private GameObject upgradeUI;
    private GameObject EscolherUI;
    private TextMeshProUGUI upgradeTXT;




    private Transform Alvo = null;
    private float cooldown;
    private int lvl = 0;

    private TorretaStatus level(int lvl)
    {
        return Levels[lvl];
    }

    void Start()
    {
        BalasPorSec = level(lvl).velAttk;
        Range = level(lvl).Range;
        Dano = level(lvl).Dano;
        Menus menuAUsar = MenuManager.main.GetMenuSelecionado();
        upgradeUI = menuAUsar.upgradeUI;
        upgradeTXT = menuAUsar.upgradeTXT;
        EscolherUI = menuAUsar.CompraUI;
        botaoUpgrade = menuAUsar.upgradeBTN;
        AtivarUIUpgrade();
        botaoUpgrade.onClick.AddListener(Upgrade);
        upgradeTXT.SetText("Upgrade : " + level(lvl).Preco);
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
        int crit = Random.Range(0, 101);
        if (crit <= level(lvl).critChance)
        {
            balacodigo.PegarValorDano(Mathf.RoundToInt((Dano * level(lvl).critDMG)));
            Debug.Log(level(lvl).critDMG);
        }
        else
        {
            balacodigo.PegarValorDano(Mathf.RoundToInt(Dano));
        }
            
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
        if (level(lvl).Preco > manager.main.moedas) return;
        if (lvl >= (Levels.Length -1))
        {
            return;
        }
        manager.main.gastarDinheiro(Mathf.RoundToInt( level(lvl).Preco));
        lvl++;
        BalasPorSec = level(lvl).velAttk;
        Range = level(lvl).Range;
        Dano = level(lvl).Dano;
        if (lvl >= (Levels.Length - 1))
        {
            upgradeTXT.SetText("Max Level");
        }
        else
        {
            upgradeTXT.SetText("Upgrade : " + level(lvl).Preco);
        }
    }
}
