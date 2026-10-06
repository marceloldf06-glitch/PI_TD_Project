using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] TextMeshProUGUI moedasUI;
    [SerializeField] TextMeshProUGUI vidaUI;
    [SerializeField] TextMeshProUGUI waveUI;
    [SerializeField] TextMeshProUGUI velUI;
    [SerializeField] Animator Anim;
    [Header("Chest")]
    [SerializeField] TextMeshProUGUI ChestUI;
    [SerializeField] GameObject chestGambler;
    [SerializeField] List<Sprite> items;
    [SerializeField] Image i1;
    [SerializeField] Image i2;
    [SerializeField] Image i3;
    [SerializeField] TextMeshProUGUI botaochest;
    [Header("Inv")]
    [SerializeField] GameObject Inventory;
    [SerializeField] Image[] slots;
    [SerializeField] TextMeshProUGUI tituloitem;
    [SerializeField] TextMeshProUGUI descitem;
    private bool menuAberto = true;
    private bool ispause;
    private float vel = 1;
    private bool chestMenuAberto = false;
    private int r1;
    private int r2;
    private int r3;
    private bool bp = false;
    private int slot = 0;
    private bool invf = false;
    private bool temitem = true;
    

    public void AcinonarMenu()
    {
        menuAberto = !menuAberto;
        Anim.SetBool("MenuAbre", menuAberto);   
    }
    private void OnGUI()
    {
       moedasUI.text = manager.main.moedas.ToString();
       vidaUI.text = manager.main.vida.ToString();
       waveUI.text = ESpawner.WaveAtual.ToString();
       ChestUI.text = manager.main.baus.ToString();
    }

    public void pausar()
    {
        if (ispause)
        {
            Time.timeScale = vel;
            ispause = !ispause;
        }else if (!ispause)
        {
            Time.timeScale = 0f;
            ispause = !ispause;
            velUI.SetText("0");
        }
    }
    public void mudarvel()
    {
        if (vel == 0 || vel == 1)
        {
            vel = 1.5f;
        }else if (vel == 1.5f)
        {
            vel = 2f;
        } else if (vel == 2f)
        {
            vel = 1f;
        }
    }
    public void voltar()
    {
        SceneManager.LoadScene("MenuInicial");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = vel;
        i1.sprite = items[0];
        i2.sprite = items[0];
        i3.sprite = items[0];
        chestGambler.SetActive(chestMenuAberto);
        Inventory.SetActive(chestMenuAberto);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Time.timeScale = vel;
        velUI.SetText(vel.ToString());
    }

    public void chest()
    {
        if (manager.main.baus > 0)
        {
            
            if (!bp && !invf && temitem) { 
            manager.main.baus--;
                
                    r1 = Random.Range(1, items.Count);
                    r2 = Random.Range(1, items.Count);
                    r3 = Random.Range(1, items.Count);
                    if (items.Count >= 3)
                    {
                        while (r1 == r2)
                        {
                            r2 = Random.Range(1, items.Count);
                        }
                    }
                    if (items.Count >= 4)
                    {
                        while (r3 == r2 || r3 == r1)
                        {
                            r3 = Random.Range(1, items.Count);
                            
                        }
                    }
                    i1.sprite = items[r1];
                    i2.sprite = items[r2];
                    i3.sprite = items[r3];
                    bp = true;
            
                
            }
        }
    }
    public void abChest()
    {
        if (chestMenuAberto)
        {
            return; 
        }
        chestMenuAberto = !chestMenuAberto;
       chestGambler.SetActive(chestMenuAberto); 
    }
    public void rchest(int i)
    {
        if (bp)
        {
            if (slot <= slots.Length - 1)
            {


                if (i == 1)
                {
                    slots[slot].sprite = i1.sprite;
                    GlobalBuffManager.main.pegarbuff(i1.sprite);
                    items.RemoveAt(r1);
                }
                else if (i == 2)
                {
                    slots[slot].sprite = i2.sprite;
                    items.RemoveAt(r2);
                    GlobalBuffManager.main.pegarbuff(i2.sprite);
                }
                else if (i == 3)
                {
                    slots[slot].sprite = i3.sprite;
                    items.RemoveAt(r3);
                    GlobalBuffManager.main.pegarbuff(i3.sprite);
                }
                if (items.Count == 1)
                {
                    temitem = false;
                    botaochest.SetText("Acabou os items");
                }
                
            }
            else
            {
                invf = true;
                botaochest.SetText("Inventario Cheio");
            }
            bp = false;
            i1.sprite = items[0];
            i2.sprite = items[0];
            i3.sprite = items[0];
            slot++;

        }
    }
    public void abInv()
    {
        if (chestMenuAberto)
        {
            return;
        }
        chestMenuAberto = true;
        Inventory.SetActive(chestMenuAberto);
    }
    public void fechar_menu()
    {
        chestMenuAberto = false;
        Inventory.SetActive(chestMenuAberto);
        chestGambler.SetActive(chestMenuAberto);
        
    }
    public void mostradesc(int pos)
    {
        tituloitem.SetText(slots[pos].sprite.name);
        descitem.SetText(descriprion(slots[pos].sprite))
    }
}
