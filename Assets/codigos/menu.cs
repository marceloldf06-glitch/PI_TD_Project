using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] TextMeshProUGUI moedasUI;
    [SerializeField] TextMeshProUGUI vidaUI;
    [SerializeField] TextMeshProUGUI waveUI;
    [SerializeField] TextMeshProUGUI ChestUI;
    [SerializeField] GameObject chestGambler;
    [SerializeField] Animator Anim;

    private bool menuAberto = true;
    private bool ispause;
    private float vel = 1;
    private bool chestAb = false;
    private bool chestMenuAberto = false;
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
        }
    }
    public void abChest()
    {
        chestMenuAberto = !chestMenuAberto;
       chestGambler.SetActive(chestMenuAberto); 
    }
}
