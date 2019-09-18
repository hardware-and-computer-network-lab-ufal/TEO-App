using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Definicoes : MonoBehaviour {

    public GameObject[] opcoes;
    private Button setaAvancar, setaVoltar;
    [SerializeField] private int indice = 0; //o elemento zero eh o pai

    // Use this for initialization
    void Start()
    {
        setaAvancar = GameObject.Find("Avancar").GetComponent<Button>();
        setaVoltar = GameObject.Find("Voltar").GetComponent<Button>();

        opcoes = GameObject.FindGameObjectsWithTag("definicoes");
        opcoes[indice].gameObject.SetActive(false);

        setaAvancar.onClick.AddListener(() => SetaAvancar());

        setaVoltar.onClick.AddListener(() => SetaVoltar());
        



    }

    void SetaAvancar()
    {
        opcoes[indice].gameObject.SetActive(false);

        ++indice;

        if (indice > opcoes.Length-1)
        {
            indice = 0;
        }

        opcoes[indice].SetActive(true);

        TEOManager.instance.MudaIdioma();

    }

    void SetaVoltar()
    {
        opcoes[indice].SetActive(false); //setando o atual para falso

        --indice;

        if (indice < 0)
        {
            indice = opcoes.Length-1; //pegando o tam da lista pra ir pro ultimo item 
        }

        opcoes[indice].SetActive(true); //setando o novo para verdadeiro
        TEOManager.instance.MudaIdioma();
    }
}
