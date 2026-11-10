using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlloader : MonoBehaviour
    
{
    public int fase;
    
    private void OnMouseDown()
    {
        if (fase == -1) return;
        SceneManager.LoadScene(fase);
    }
}
