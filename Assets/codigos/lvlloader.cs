using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlloader : MonoBehaviour
    
{
    [Header("referencia")]
    [SerializeField] private int fase;
    
    private void OnMouseDown()
    {
        SceneManager.LoadScene(fase);
    }
}
