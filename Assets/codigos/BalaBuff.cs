using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BalaBuff : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Rigidbody2D rb;
    private int buff;
    public void PegarBuff(int _buff)
    {
        buff = _buff;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Torreta>().LevarBuff(buff);
         Destroy(gameObject);
    }
}
