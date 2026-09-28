using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene("Select");
    }
    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void sair()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
