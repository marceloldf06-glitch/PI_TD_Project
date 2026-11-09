using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Torreta : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Transform pontoDeRotacaoDaTorreta;
    [SerializeField] private LayerMask Emascara;
    [SerializeField] private GameObject PrefabBala;
    [SerializeField] private Transform PontaDaArma;
    [SerializeField] private GameObject btnperso;

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
    private float crtdmg;
    private int pierce;
    private int slow;
    private float dotDMG;
    private float dotDur;
    private float knockback;

    private Button botaoUpgrade;
    private GameObject upgradeUI;
    private GameObject EscolherUI;
    private TextMeshProUGUI upgradeTXT;
    private Button botaovender;
    private TextMeshProUGUI status;



    private Transform Alvo = null;
    private float cooldown;
    private float cooldownB;
    private int lvl = 0;
    private int moneygasto;
    private Animator Animup;
    private Menus menuAUsar;
    private bool ativo = false;
    

    private TorretaStatus level(int lvl)
    {
        return Levels[lvl];
    }

    void Start()
    {
        menuAUsar = MenuManager.main.GetMenuSelecionado();
        Animup = MenuManager.main.GetAnimator();
        atualizarstatus();



    }
    private void FixedUpdate()
    {
        if (MenuManager.main.reset)
        {
            if (menuAUsar.nome.text.Equals(nome) )
            {
                if (ativo)
                { return; }
                else
                {
                    upgradeTXT = null;
                    botaoUpgrade = null;
                    botaovender = null;
                    status = null;
                    botaoUpgrade.onClick.RemoveAllListeners();
                    botaovender.onClick.RemoveAllListeners();
                    MenuManager.main.reset = false;
                }
            }
            else
            {
                return;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        atualizarstatus();
        
        


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
        int crit = UnityEngine.Random.Range(1, 100);
        if (crit >= (100 - crtc))
        {
            balacodigo.PegarValorDano(Mathf.RoundToInt(Dano * crtdmg));
        }
        else
        {
            balacodigo.PegarValorDano(Mathf.RoundToInt(Dano));
        }
        balacodigo.pegarPierce(pierce);
        balacodigo.pegarSlow(slow);
        balacodigo.pegardot(dotDMG, dotDur);
        balacodigo.pegarback(knockback);
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

    public void switchupgrade()
    {
        Animup.SetBool("MenuUpAbre", MenuManager.main.upab);
        MenuManager.main.upab = !MenuManager.main.upab;
        
    }
    public void OnMouseDown()
    {
        if (MenuManager.main.upab)
        {
        attupdstatus();
        switchupgrade();
            
            
        }
        else
        {
            if (menuAUsar.nome.text.Equals(nome))
            {
                switchupgrade();
                
            }
            else
            {
                
                attupdstatus();
            }
            
        }
    }
    public void vender()
    {
        if (menuAUsar.nome.text.Equals(nome))
        {
            int dinheirovenda;
            dinheirovenda = dinheirogasto();
            manager.main.ganharDinheiro((int)dinheirovenda);
            lvl = 0;
            MenuManager.main.upab = false;
            GameObject.Destroy(gameObject);
        }
    }
    public int dinheirogasto()
    {
        
        for (int i = 0; i <= lvl; i++)
        {
            moneygasto += (int)level(lvl).Preco;
        } 
        return Mathf.RoundToInt(moneygasto);
    }
    public void Upgrade()
    {
        if (menuAUsar.nome.text.Equals(nome)){
            if (upgradeTXT.text.Equals("Max Level")) return;
            if (level(lvl + 1).Preco > manager.main.moedas) return;
            if (lvl >= (Levels.Length - 1))
            {
                return;
            }
            manager.main.gastarDinheiro(Mathf.RoundToInt(level(lvl).Preco));
            lvl++;
            atualizarstatus();
            attupdstatus();
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
    public void attupdstatus()
    {
        MenuManager.main.reset = true;
            for (float i = 0f; i <= 1f; i+= Time.deltaTime){}
            ativo = true;
            menuAUsar.nome.SetText(nome);
            upgradeTXT = menuAUsar.upgradeTXT;
            botaoUpgrade = menuAUsar.upgradeBTN;
            botaovender = menuAUsar.vender;
            status = menuAUsar.statuspanel;
            botaoUpgrade.onClick.AddListener(Upgrade);
            botaovender.onClick.AddListener(vender);
            if (lvl == 0)
            {
                upgradeTXT.SetText("Upgrade : " + level(lvl + 1).Preco);
            }

            menuAUsar.imagem.sprite = imgperso;
            String desc = "";
            desc += "\n<sprite=0>: " + BalasPorSec;
            desc += "\n<sprite=7>: " + Dano;
            desc += "\n<sprite=8>: " + Range;

            if (crtc > 0)
            {
                desc += "\n<sprite=6>: " + crtc;
            }
            if (crtdmg > 0)
            {
                desc += "\n<sprite=5>: " + crtdmg;
            }
            if (pierce > 0)
            {
                desc += "\n<sprite=8>: " + pierce;
            }
            if (slow > 0)
            {
                desc += "\n<sprite=1>: " + slow;
            }
            if (knockback > 0)
            {
                desc += "\n<sprite=2>: " + knockback;
            }
            if (dotDMG > 0)
            {
                desc += "\n<sprite=3>: " + dotDMG;
            }
            if (dotDur > 0)
            {
                desc += "\n<sprite=4>: " + dotDur;
            }

            status.SetText(desc);
        }
    
    
    private void atualizarstatus()
    {
        BalasPorSec = level(lvl).velAttk + GlobalBuffManager.main.velAttk;
        Range = level(lvl).Range + GlobalBuffManager.main.Range;
        Dano = level(lvl).Dano + GlobalBuffManager.main.Dano;
        crtc = level(lvl).critChance + GlobalBuffManager.main.critChance;
        crtdmg = level(lvl).critDMG + GlobalBuffManager.main.critDMG;
        pierce = level(lvl).pierce + GlobalBuffManager.main.pierce;
        if (pierce < 0)
        {
            pierce = 0;
        }
        slow = level(lvl).slow + GlobalBuffManager.main.slow;
        if (slow < 0)
        {
            slow = 0;
        }
        dotDur = level(lvl).dotDur + GlobalBuffManager.main.dotDur;
        if (dotDur < 0)
        {
            dotDur = 0;
        }
        dotDMG = level(lvl).dotDMG + GlobalBuffManager.main.dotDMG;
        knockback = level(lvl).knockback + GlobalBuffManager.main.knockback;
        if (knockback < 0)
        {
            knockback = 0;
        }

        if (crtdmg < 1.5)
        {
            crtdmg = 1.5f;
        }
    }
}
