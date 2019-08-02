﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuebraCabecaManager : MonoBehaviour {

    public static QuebraCabecaManager instance;
    public GameObject panelParabens;
    public GameObject panelEstatisticas;
    public GameObject popup_voltar;
    private int contador_pecas; //Vai contar quantas pecas ja foram colocadas no lugar
    private Animator parabensAnim,popup_voltar_anim;
    public GameObject fundo;

    public UsuarioJoga usuario;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //temporariamente
		usuario.cpf = PlayerPrefs.GetString("cpf", "12345678901");
        usuario.nomeJogo = "Quebra-Cabeça";
    }

    void Start () {
        StartCoroutine(DesligaPanel());

        if (PlayerPrefs.GetInt("nivel") == 3)
        {
            //print(fundo.gameObject.GetComponentsInChildren<SpriteRenderer>());
            //for(int i = 0; i < 4; i++)
            //{
            //    print(fundo.gameObject.GetComponentsInChildren<SpriteRenderer>()[i]);
            //}
            for (int i=0;i<4;i++)
            {
                Sprite img = Resources.Load<Sprite>("Jogos/quebracabeca/pecas_brancas/"+(i+1)+"_4");
                fundo.gameObject.GetComponentsInChildren<Image>()[i].sprite = img;
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator DesligaPanel()
    {
        yield return new WaitForSeconds(0.001f);
        parabensAnim = panelParabens.GetComponent<Animator>();
        popup_voltar_anim = popup_voltar.GetComponent<Animator>();
        panelParabens.SetActive(false);
        popup_voltar.SetActive(false);
        panelEstatisticas.SetActive(false);
    }

    IEnumerator VoltaPanelParabens()
    {
        yield return new WaitForSeconds(5);
        parabensAnim.Play("panel_parabens_reverse");
        yield return new WaitForSeconds(1);
        panelEstatisticas.SetActive(true);
        panelParabens.SetActive(false);
    }

    public void JogarNovamente()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ContaPecas()
    {
        contador_pecas++;

        if (contador_pecas == 4)
        {
            panelParabens.SetActive(true);
            parabensAnim.Play("panel_parabens");
            Musica.instance.OnCongrats();
            usuario.quantidadeAcertos = contador_pecas;
            usuario.tempoJogo = (int)Time.timeSinceLevelLoad;
            Login.conexao.addUsuarioJoga(usuario);
            StartCoroutine(VoltaPanelParabens());
        } 
    }

    public void PausePopup()
    {
        popup_voltar.SetActive(true);
        popup_voltar_anim.Play("popup_voltar");
        //Time.timeScale = 0; //forma de pausar os objetos do jogo
    }

    public void Continue()
    {
        //Time.timeScale = 1; //despausar jogo
        popup_voltar_anim.Play("popup_voltar_inverse");
    }
}
