using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JogosManager : MonoBehaviour {

    [System.Serializable]
    public class Botao
    {
        public string nome;
    }

    [SerializeField]
    private List<Botao> iniciante;
    [SerializeField]
    private List<Botao> intermediario;
    [SerializeField]
    private List<Botao> avancado;

    public Transform prateleira;
    public GameObject botao;

    // Use this for initialization
    void Start () {
        print("Start");
        int nivel = PlayerPrefs.GetInt("nivel");
        print(nivel);
        if (nivel==1)
        {
            InstanciaBotao(iniciante);
        } else if (nivel == 2)
        {
            InstanciaBotao(intermediario);
        } else if (nivel == 3)
        {
            InstanciaBotao(avancado);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void InstanciaBotao(List<Botao> lista)
    {
        foreach (Botao b in lista)
        {
            GameObject botaoObj = Instantiate(botao) as GameObject; //instancia um botao como gameobject da cena
            botaoObj.transform.SetParent(prateleira, false); //seta o local para dentro da prateleira(painel)
            Button botaoNovo = botaoObj.GetComponent<Button>(); //pega o gameobj e transforma num botao

            botaoNovo.image.sprite = Resources.Load<Sprite>("Jogos/" + b.nome); //altera a img do botao

            if (b.nome == "numeros") //teste!!!
            {
                botaoNovo.onClick.AddListener( //chamando a cena com o nome do jogo
                () =>
                {
                    GoJogo(b.nome);
                }
            );
            }


        }
    }

    void GoJogo(string nome)
    {
        SceneManager.LoadScene(nome);
    }
}
