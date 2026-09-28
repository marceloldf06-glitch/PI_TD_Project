using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlloader : MonoBehaviour

{
    private int fase = 3;
    
    private void OnMouseDown()
    {
        SceneManager.LoadScene(fase);
    }
}
