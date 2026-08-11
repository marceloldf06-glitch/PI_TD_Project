using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public static manager main;

    public Transform SP;
    public Transform[] caminho;

    private void Awake()
    {
        main = this;
    }
}
