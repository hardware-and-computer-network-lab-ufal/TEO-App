using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel : MonoBehaviour {

    [SerializeField]
    private GameObject nivelTela;
    private Animator animacao;

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
        SceneManager.LoadScene(1);
    }

    public void Medio()
    {
        SceneManager.LoadScene(1);
    }

    public void Dificil()
    {
        SceneManager.LoadScene(1);
    }

    public void Voltar()
    {
        animacao.Play("tela_nivel_inverse");
    }
	
}
