using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public static MenuManager main;
    private Animator animmenup;
    public bool upab = true;
    public bool reset = true;
    private void Awake()
    {
        main = this;
    }
    [SerializeField] Menus menus;


    public Menus GetMenuSelecionado()
    {
        return menus;
    }
    public void SetAnimator(Animator _anime)
    {
        animmenup = _anime;
    }
    public Animator GetAnimator()
    {
        return animmenup;
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
