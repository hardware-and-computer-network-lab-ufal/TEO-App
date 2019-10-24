using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NivelManager : MonoBehaviour {

    public static NivelManager instance;
    [SerializeField]
    private GameObject nivelTela,loginTela,esqueciTela,emBreveTela;
    private Animator animacao,loginAnim,esqueciAnim,emBreveAnim;
    public int nivel;
    [SerializeField]private Button playBtn;
    [SerializeField] private Button facilBtn,medioBtn,dificilBtn; //botoes nivel

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        if (SceneManager.GetActiveScene().buildIndex == 0) //verificando se esta na cena do menu p nao dar erro em outras cenas
        {
            SceneManager.sceneLoaded += CarregaCena; //sempre que a cena abrir vai carregar esses objs
        }

    }

    private void Start()
    {
        SceneManager.sceneLoaded += CarregaCena;
        nivelTela.SetActive(false);


    }

    void CarregaCena(Scene cena, LoadSceneMode modo) //carregar objetos importantes da cena 
    {
        //componentes da tela de níveis
        nivelTela = GameObject.Find("Niveis");
        loginTela = GameObject.Find("Login");
        esqueciTela = GameObject.Find("EsqueciAsenha");
        emBreveTela = GameObject.Find("AlertaCadastrar");
        animacao = nivelTela.GetComponent<Animator>();
        loginAnim = loginTela.gameObject.GetComponent<Animator>();
        esqueciAnim = esqueciTela.gameObject.GetComponent<Animator>();
        emBreveAnim = emBreveTela.gameObject.GetComponent<Animator>();
        facilBtn = GameObject.Find("inicianteBtn").GetComponent<Button>();
        medioBtn = GameObject.Find("intermediarioBtn").GetComponent<Button>();
        dificilBtn = GameObject.Find("avancadoBtn").GetComponent<Button>();
        facilBtn.onClick.AddListener(() => { Facil(); });
        medioBtn.onClick.AddListener(() => { Medio(); });
        dificilBtn.onClick.AddListener(() => { Dificil(); });

        //Botao play
        playBtn = GameObject.Find("PlayButton").GetComponent<Button>();
        playBtn.onClick.AddListener(() => {
            // try {
            //     if (Login.conexao.conectado == false){
            //         TelaLogin();
            //     } else {
            //         DesativaMenu();
            //         TelaNivel();
            //     }
            // }
            // catch (System.Exception) {
            //     TelaLogin();
            // }
            
            //Avançar de Login para Niveis, release v1.0
            TelaLogin();
            TelaNivel();
            TEOManager.instance.MudaIdioma();
        });
    }

    IEnumerator DesligaLoginTela()
    {
        loginAnim.Play("login_inverse");
        yield return new WaitForSeconds(1);
        loginTela.SetActive(false);
    }

    //IEnumerator DesligaEsqueciTela()
    //{
    //    esqueciAnim.Play("esqueciAsenha_inverse");
    //    yield return new WaitForSeconds(1);
    //    loginTela.SetActive(false);
    //}

    public void TelaNivel()
    {
        StartCoroutine(DesligaLoginTela());
        nivelTela.SetActive(true);
        TEOManager.instance.MudaIdioma();
        animacao.Play("tela_nivel");
    }

    public void TelaEsqueciAsenha()
    {
        StartCoroutine(DesligaLoginTela());
        esqueciTela.SetActive(true);
        esqueciAnim.Play("esqueciAsenha");
    }

    private void TelaAlerta()
    {
        StartCoroutine(DesligaLoginTela());
        emBreveTela.SetActive(true);
        TEOManager.instance.MudaIdioma();
        emBreveAnim.Play("confirmar_saida");
        StartCoroutine(VoltaAlerta());
        
    }
    
    IEnumerator VoltaAlerta()
    {
        yield return new WaitForSeconds(2);
        emBreveAnim.Play("confirmar_saida_inverse");
        TelaLogin();
        yield return new WaitForSeconds(2);
        emBreveTela.SetActive(false);
       
    }

    private void DesativaMenu()
    {
        if (GameObject.Find("Menu")!=null)
        {
            GameObject.Find("Menu").gameObject.SetActive(false);
        }
        if (GameObject.Find("Teo-Main")!=null)
        {
            GameObject.Find("Teo-Main").gameObject.SetActive(false);
        }
        
       
    }

    public void TelaLogin()
    {
        DesativaMenu();
        loginTela.SetActive(true);
        loginAnim.Play("login");
        // GameObject.Find("naologar_label").GetComponent<Button>().onClick.AddListener(
        //     () =>
        //     {
        //         TelaNivel();
        //     }
        // );
        GameObject.Find("esqueci_btn").GetComponent<Button>().onClick.AddListener(
            () =>
            {
                TelaEsqueciAsenha();
            }
        );
        GameObject.Find("cadastrar_btn").GetComponent<Button>().onClick.AddListener(
            () =>
            {
                TelaAlerta();
            }    
        );
        loginAnim.Play("login");
    }

    public void Facil()
    {
        PlayerPrefs.SetInt("nivel",1);
        nivel = 1;
        Voltar();
        nivelTela.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void Medio()
    {
        PlayerPrefs.SetInt("nivel", 2);
        this.nivel = 2;
        Voltar();
        nivelTela.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void Dificil()
    {
        PlayerPrefs.SetInt("nivel", 3);
        this.nivel = 3;
        Voltar();
        nivelTela.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void Voltar()
    {
        animacao.Play("tela_nivel_inverse");
    }
	
}
