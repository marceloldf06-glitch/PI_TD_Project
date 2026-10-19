using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

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

    [Header("Dx td bunito")]
    [SerializeField] private Sprite imgperso;
    [SerializeField] private string nome;



    


    private float BalasPorSec;
    private float Dano;
    private int precoUpgradeBase;
    private float Range;
    private float crtc;

    private Button botaoUpgrade;
    private GameObject upgradeUI;
    public GameObject EscolherUI;
    private TextMeshProUGUI upgradeTXT;
    private Button botaovender;
    private TextMeshProUGUI status;



    private Transform Alvo = null;
    private float cooldown;
    private float cooldownB;
    private int lvl = 0;
    private bool upab = true;

    private Animator Animup;



    private TorretaStatus level(int lvl)
    {
        return Levels[lvl];
    }

    void Start()
    {
        Animup = MenuManager.main.GetAnimator();
        BalasPorSec = level(lvl).velAttk + GlobalBuffManager.main.velAttk;
        Range = level(lvl).Range + GlobalBuffManager.main.Range;
        Dano = level(lvl).Dano + GlobalBuffManager.main.Dano;
        Menus menuAUsar = MenuManager.main.GetMenuSelecionado();
        upgradeTXT = menuAUsar.upgradeTXT;
        botaoUpgrade = menuAUsar.upgradeBTN;
        botaovender = menuAUsar.vender;
        status = menuAUsar.statuspanel;
        botaoUpgrade.onClick.AddListener(Upgrade);
        upgradeTXT.SetText("Upgrade : " + level(lvl+1).Preco);
        botaovender.onClick.AddListener(vender);
        
    }

    // Update is called once per frame
    void Update()
    {
        BalasPorSec = level(lvl).velAttk + GlobalBuffManager.main.velAttk;
        Range = level(lvl).Range + GlobalBuffManager.main.Range;
        Dano = level(lvl).Dano + GlobalBuffManager.main.Dano;
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
        crtc = level(lvl).critChance + GlobalBuffManager.main.critChance;
        GameObject balaobj = Instantiate(PrefabBala, PontaDaArma.position, Quaternion.identity);
        Bala balacodigo = balaobj.GetComponent<Bala>();
        balacodigo.MarcarAlvo(Alvo);
        int crit = Random.Range(1, 100);
        if (crit >= (100 - crtc))
        {
            balacodigo.PegarValorDano(Mathf.RoundToInt((Dano * (level(lvl).critDMG + GlobalBuffManager.main.critDMG))));
        }
        else
        {
            balacodigo.PegarValorDano(Mathf.RoundToInt(Dano ));
        }
        balacodigo.pegarPierce(level(lvl).pierce + GlobalBuffManager.main.pierce);
        balacodigo.pegarSlow(level(lvl).slow + GlobalBuffManager.main.slow);
        balacodigo.pegardot(level(lvl).dotDMG + GlobalBuffManager.main.dotDMG, level(lvl).dotDur + GlobalBuffManager.main.dotDur);
        balacodigo.pegarback(level(lvl).knockback + GlobalBuffManager.main.knockback);
        Alvo = null;
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
        Animup.SetBool("MenuUpAbre", true);
        upab = false;
    }
    public void DesativarUpgradeUI()
    {
        Animup.SetBool("MenuUpAbre", false);
        upab = true;
    }
    public void OnMouseDown()
    {
        if (upab)
        {
            AtivarUIUpgrade();
            attupdstatus();
        }
        else
        {
            DesativarUpgradeUI();
            attupdstatus();
        }
    }
    public void vender()
    {
        lvl = 0; 
        GameObject.Destroy(gameObject);
        int dinheirovenda;
        dinheirovenda = 1;
        manager.main.ganharDinheiro(dinheirovenda);
        DesativarUpgradeUI();
    }
    public void Upgrade()
    {
        if (level(lvl+1).Preco > manager.main.moedas) return;
        if (lvl >= (Levels.Length -1))
        {
            return;
        }
        manager.main.gastarDinheiro(Mathf.RoundToInt( level(lvl).Preco));
        lvl++;
        if (lvl >= (Levels.Length - 1))
        {
            upgradeTXT.SetText("Max Level");
        }
        else
        {
            upgradeTXT.SetText("Upgrade : " + level(lvl).Preco);
        }
        attupdstatus();
    }
    public void attupdstatus()
    {
        status.SetText("Dano:" + Dano + "\nRange" + Range + "\nVelocidade de Ataque" + BalasPorSec);
    }
}
