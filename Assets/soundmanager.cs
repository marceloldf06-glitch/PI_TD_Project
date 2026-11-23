using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class soundmanager : MonoBehaviour
{
    [Header("Audios")]
    [SerializeField] private AudioClip[] audios;
    [SerializeField] private AudioSource player;
    public static soundmanager main;
    void Start()
    {
        main = this;    
    }
    public void play(int i)
    {
        player.PlayOneShot(audios[i], 1);
    } 
}
