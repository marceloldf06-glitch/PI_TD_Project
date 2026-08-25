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
    [SerializeField] Animator Anim;

    private bool menuAberto = true;
    private bool ispause;
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
        
    }

    public void pausar()
    {
        if (ispause)
        {
            Time.timeScale = 1;
            ispause = !ispause;
        }else if (!ispause)
        {
            Time.timeScale = 0;
            ispause = !ispause;
        }
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
}
