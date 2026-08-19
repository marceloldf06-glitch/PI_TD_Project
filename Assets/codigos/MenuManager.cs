using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public static MenuManager main;

    private void Awake()
    {
        main = this;
    }
    [SerializeField] Menus[] menus;
    private int menuselecionado = 0;


    public Menus GetMenuSelecionado()
    {
        return menus[menuselecionado];
    }

    public void setarTorre(int _menuSelecionado)
    {
        menuselecionado = _menuSelecionado;
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
