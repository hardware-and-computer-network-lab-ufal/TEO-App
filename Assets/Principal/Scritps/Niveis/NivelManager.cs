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
    }

    private void Start()
    {
        animacao = nivelTela.GetComponent<Animator>();

    }
    public void TelaNivel()
    {
        nivelTela.SetActive(true);
        animacao.Play("tela_nivel");
        
    
    }

    public void Facil()
    {
        nivel = 1;
        print(nivel);
        SceneManager.LoadScene(1);
    }

    public void Medio()
    {
        this.nivel = 2;
        SceneManager.LoadScene(1);
    }

    public void Dificil()
    {
        this.nivel = 3;
        SceneManager.LoadScene(1);
    }

    public void Voltar()
    {
        animacao.Play("tela_nivel_inverse");
    }
	
}
