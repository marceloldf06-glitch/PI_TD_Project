using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class ESpawner : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private GameObject[] EPrefab;

    [Header("Atributos")]
    [SerializeField] private int QEnimigos = 8;
    [SerializeField] private float EPorSegundo = 0.5f;
    [SerializeField] private float TEntreWaves = 5f;
    [SerializeField] private float escalaDeDificuldade = 0.75f;
    [SerializeField] private float EporSegundoMax = 10f;

    [Header("Eventos")]
    public static UnityEvent emEDestruido = new UnityEvent();

    private int WaveAtual = 1;
    private float TDeisDoUltimoSpawn;
    private int Evivos;
    private int EaSpawnar;
    private bool Spawnando = false;
    private float EPS;

    private void Awake()
    {
        emEDestruido.AddListener(EDestruido);
    }

    private void Start()
    {
        StartCoroutine(comecarWave());
    }
    private void Update()
    {
        if (!Spawnando) return;
        TDeisDoUltimoSpawn += Time.deltaTime; 

        if(TDeisDoUltimoSpawn >= (1f/EPS) && EaSpawnar > 0)
        {
            SpawnarE();
            EaSpawnar--;
            Evivos++;
            TDeisDoUltimoSpawn = 0f;
        }

        if(Evivos == 0 && EaSpawnar == 0)
        {
            AcabarWave();  
        }


    }

    private void EDestruido ()
    {
        Evivos--;
    }
    private void SpawnarE()
    {
        int index = Random.Range(0, EPrefab.Length);
        GameObject EPrefabaSpawnar = EPrefab[index];
        
        GameObject Espawnado = Instantiate(EPrefabaSpawnar, manager.main.SP.position, Quaternion.identity);
        Inimigo inimigo = Espawnado.GetComponent<Inimigo>();

        inimigo.SetHP(inimigo.GetHp() * Mathf.Pow(WaveAtual, escalaDeDificuldade));
        inimigo.SetvaleQuanto(inimigo.GetvaleQuanto() * Mathf.Pow(WaveAtual, escalaDeDificuldade));

        Debug.Log(inimigo.GetHp());
    }
    private IEnumerator comecarWave()
    {
        yield return new WaitForSeconds(TEntreWaves);
        Spawnando = true;
        EaSpawnar = EporWave();
        EPS = EporSec();
        
    }
   private void AcabarWave()
    {
        Spawnando = false;
        TDeisDoUltimoSpawn = 0f;
        WaveAtual++;
        StartCoroutine(comecarWave());
    }
    private int EporWave()
    {
        return Mathf.RoundToInt(QEnimigos * Mathf.Pow(WaveAtual, escalaDeDificuldade));
    }
    
    private float EporSec()
    {
        return Mathf.Clamp((EPorSegundo * Mathf.Pow(WaveAtual, escalaDeDificuldade)), 0, EporSegundoMax);
    }
    // Update is called once per frame

}
