using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [Header("Atributos")]
    [SerializeField] private float hp = 2;
    [SerializeField] private float valeQuanto = 10;
    [SerializeField] private float hpBase;
    [SerializeField] private float valeQuantoBase;
    private bool isDestroyed = false;
    private float dotdmg;
    private float dotdur;
    private int i;

    void Start()
    {
    }
    public void SetHP(float _hp)
    {
        hp = _hp;
    }
    public float GetHp()
    {
        return hpBase;
    }
    public void SetvaleQuanto(float _valeQuanto)
    {
        valeQuanto = _valeQuanto;
    }
    public float GetvaleQuanto()
    {
        return valeQuantoBase;
    }
    public void LevarDano (int Dano)
    {
        hp -= Dano;
        if (hp <= 0 && !isDestroyed)
        {
            ESpawner.emEDestruido.Invoke();
            manager.main.ganharDinheiro(Mathf.RoundToInt(valeQuanto));
            isDestroyed = true;
            Destroy(gameObject);
            int cc = Random.Range(1, 100);
            if (cc <= 1)
            {
                manager.main.baus++;
            }
        }
    }
    public void LevarDot(float _dotdmg,float _dotdur)
    {
        dotdmg += _dotdmg;  dotdur += _dotdur;
        
    }


    // Start is called before the first frame update


    // Update is called once per frame
    private void FixedUpdate()
    {
        
        if (i <= dotdur)
        {
            hp -= dotdmg;
            i++;
        }

    }
}
