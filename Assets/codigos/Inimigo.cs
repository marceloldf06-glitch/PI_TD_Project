using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [Header("Atributos")]
    [SerializeField] private int hp = 2;
    

    public void LevarDano (int Dano)
    {
        hp -= Dano;
        if (hp <= 0)
        {
            ESpawner.emEDestruido.Invoke();
            Destroy(gameObject);
        }
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
