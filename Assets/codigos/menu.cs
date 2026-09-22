using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] TextMeshProUGUI moedasUI;
    [SerializeField] TextMeshProUGUI vidaUI;
    [SerializeField] TextMeshProUGUI waveUI;
    [SerializeField] Animator Anim;
    [Header("Chest")]
    [SerializeField] TextMeshProUGUI ChestUI;
    [SerializeField] GameObject chestGambler;
    [SerializeField] Sprite[] items;
    [SerializeField] Image i1;
    [SerializeField] Image i2;
    [SerializeField] Image i3;
    private bool menuAberto = true;
    private bool ispause;
    private float vel = 1;
    private bool chestMenuAberto = false;
    private int r1;
    private int r2;
    private int r3;

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
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Time.timeScale = vel;
    }

    public void chest()
    {
        if (manager.main.baus > 0)
        {
            manager.main.baus--;
            if (items.Length > 1)
            {
                i1.sprite = items[0];
                i2.sprite = items[0];
                i3.sprite = items[0];
            }
        }
    }
    public void abChest()
    {
        chestMenuAberto = !chestMenuAberto;
       chestGambler.SetActive(chestMenuAberto); 
    }
    public void rchest(int i)
    {
        i1.sprite = items[0];
        i2.sprite = items[0];
        i3.sprite = items[0];
    }
}
