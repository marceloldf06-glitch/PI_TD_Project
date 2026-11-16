using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fasesliberadas : MonoBehaviour
{
    public static fasesliberadas Instance;

    public int fasecompletada;

    private void Awake()
    {
        if (fasesliberadas.Instance == null)
        {
            fasesliberadas.Instance = this;
            DontDestroyOnLoad((this.gameObject));
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void completar()
    {
        fasecompletada++;
    }
}
