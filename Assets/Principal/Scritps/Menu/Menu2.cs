using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu2 : MonoBehaviour {

    [SerializeField]
    private GameObject confirmaSaida;
    private Animator confirma;

	public void PlaySuiteGames(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

    public void ConfirmaSaida()
    {
        confirmaSaida.SetActive(true);
        confirma = confirmaSaida.GetComponent<Animator>();
        confirma.Play("confirmar_saida");
    }

    public void NaoSair()
    {
        confirma.Play("confirmar_saida_inverse");
    }
    

	public void QuitGame(){
        confirma.Play("confirmar_saida_inverse");
		Application.Quit ();
	}

}
