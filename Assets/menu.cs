using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class menu : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] TextMeshProUGUI moedasUI;

    private void OnGUI()
    {
        moedasUI.text = manager.main.moedas.ToString();
    }

    public void setarTorre()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
