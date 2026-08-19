using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class menu : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] TextMeshProUGUI moedasUI;
    [SerializeField] Animator Anim;

    private bool menuAberto = true;
    public void AcinonarMenu()
    {
        menuAberto = !menuAberto;
        Anim.SetBool("MenuAbre", menuAberto);   
    }
    private void OnGUI()
    {
        moedasUI.text = manager.main.moedas.ToString();
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
}
