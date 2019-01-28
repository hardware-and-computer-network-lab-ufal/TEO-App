using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NivelManager : MonoBehaviour {

    public static NivelManager instance;
    [SerializeField]
    private GameObject nivelTela;
    private Animator animacao;
    public int nivel;
    [SerializeField]private Button playBtn;
    [SerializeField] private Button facilBtn,medioBtn,dificilBtn; //botoes nivel

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        if (SceneManager.GetActiveScene().buildIndex == 0) //verificando se esta na cena do menu p nao dar erro em outras cenas
        {
            SceneManager.sceneLoaded += CarregaCena; //sempre que a cena abrir vai carregar esses objs
        }

        
    }

    private void Start()
    {
        animacao = nivelTela.GetComponent<Animator>();

        SceneManager.sceneLoaded += CarregaCena;

        nivelTela.SetActive(false);


    }

    void CarregaCena(Scene cena, LoadSceneMode modo) //carregar objetos importantes da cena 
    {
        //componentes da tela de níveis
        nivelTela = GameObject.Find("Niveis");
        facilBtn = GameObject.Find("inicianteBtn").GetComponent<Button>();
        medioBtn = GameObject.Find("intermediarioBtn").GetComponent<Button>();
        dificilBtn = GameObject.Find("avancadoBtn").GetComponent<Button>();
        facilBtn.onClick.AddListener(() => { Facil(); });
        medioBtn.onClick.AddListener(() => { Medio(); });
        dificilBtn.onClick.AddListener(() => { Dificil(); });

        //Botao play
        playBtn = GameObject.Find("PlayButton").GetComponent<Button>();
        playBtn.onClick.AddListener(() => { TelaNivel(); });
    }
    
    public void TelaNivel()
    {
        nivelTela.SetActive(true);
        animacao = nivelTela.GetComponent<Animator>();
        animacao.Play("tela_nivel");
            
    }

    public void Facil()
    {
        nivel = 1;
        Voltar();
        nivelTela.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void Medio()
    {
        this.nivel = 2;
        Voltar();
        nivelTela.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void Dificil()
    {
        this.nivel = 3;
        Voltar();
        nivelTela.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void Voltar()
    {
        animacao = nivelTela.GetComponent<Animator>();
        animacao.Play("tela_nivel_inverse");
    }
	
}
