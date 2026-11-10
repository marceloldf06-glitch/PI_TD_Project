using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnim : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] TextMeshProUGUI txtpro;
    [Header("Atributos")]
    [SerializeField] float tempoEntreCaracteres;
    [SerializeField] float tempoEntrePalavras;
    public string[] textos;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        EndCheck();
    }
    void EndCheck()
    {
        if(i <= textos.Length - 1)
        {
        txtpro.text = textos[i];
            StartCoroutine(TextoVisivel());
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator TextoVisivel()
    {
        txtpro.ForceMeshUpdate();
    int totalcaracteressvisiveis = txtpro.textInfo.characterCount;
        int contador = 0;
        while (true)
        {
            int contadorvisiveis = contador % (totalcaracteressvisiveis + 1);
            
            txtpro.maxVisibleCharacters = contadorvisiveis;
            if (contadorvisiveis >= totalcaracteressvisiveis)
            {
                i++;
                Invoke("EndCheck", tempoEntrePalavras);
                break;
            }
            contador++;
            yield return new WaitForSeconds(tempoEntreCaracteres);
        }
    }
}
