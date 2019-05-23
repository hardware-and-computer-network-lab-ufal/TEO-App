﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OndeEsta : MonoBehaviour {

	public static OndeEsta instance;
	public GameObject panelParabens;
	public GameObject panelParabensFinal;
	public GameObject popup_voltar;
    private Animator parabensAnim, popup_voltar_anim;

	public int contagemOndeEsta = 0;
	public int totalOndeEsta; // Quantidade de perguntas, definidas pela dificuldade
	 public int questao;
	public bool changeQuestion = true;

	private Queue<int> bodyParts = new Queue<int>(3);

	private void Awake() {
		if (SceneManager.GetActiveScene().buildIndex == 6) {
			if ( instance == null)
				instance = this;
		}
		panelParabensFinal = GameObject.Find("panel_parabens_final");
		panelParabensFinal.SetActive(false);
		contagemOndeEsta = 0;

		totalOndeEsta = PlayerPrefs.GetInt("nivel", 3);
		
	}

	IEnumerator DesligaPanel () {
		yield return new WaitForSeconds(0.001f);
		parabensAnim = panelParabens.GetComponent<Animator>();

        popup_voltar_anim = popup_voltar.GetComponent<Animator>();
        popup_voltar.SetActive(false);
        panelParabens.SetActive(false);
		panelParabensFinal.SetActive(false);
	}

	IEnumerator VoltaPanelParabens() {
		yield return new WaitForSeconds(5);
		parabensAnim.Play("panel_parabens_reverse");
		yield return new WaitForSeconds(1);
		panelParabensFinal.SetActive(true);
		panelParabens.SetActive(false);
	}

	public void JogarNovamente() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

	}

	public void OndeEstaCompleto() {
		if (totalOndeEsta == contagemOndeEsta) {
			Musica.instance.OnCongrats();
			
			contagemOndeEsta++;
			panelParabens.SetActive(true);
            parabensAnim.Play("panel_parabens");
            StartCoroutine("VoltaPanelParabens");
		}
	}
	public void randomChild() {
		System.Random child = new System.Random();
		int childSelected = child.Next(1,3);

		GameObject childPlace = GameObject.Find("childPlace");
		childPlace.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Jogos/OndeEsta/child" + childSelected);
	}

	public void randomParts() {
		System.Random part = new System.Random();

		while (bodyParts.Count < totalOndeEsta) {
			int choosenOne = part.Next(3);
			if (!bodyParts.Contains(choosenOne))
				bodyParts.Enqueue(choosenOne);
		}
		
	}

	public void questions() {
		if (changeQuestion == true && contagemOndeEsta < totalOndeEsta) {
			questao = bodyParts.Dequeue();
			string[] ques = new string[3];
			ques[0] = "olho";
			ques[1] = "nariz";
			ques[2] = "boca";

			GameObject questionPlace = GameObject.Find("questionPlace");
			questionPlace.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Jogos/OndeEsta/" + ques[questao]);

			changeQuestion = false;
		}
	}

	void Start () {
		panelParabens = GameObject.Find("panel_parabens");
		popup_voltar = GameObject.Find("popup_voltar");
		randomChild();
		randomParts();

		StartCoroutine("DesligaPanel");
	}
	
	void Update () {
		questions();
		OndeEstaCompleto();
	}

	public void PausePopup()
    {
        popup_voltar.SetActive(true);
        popup_voltar_anim.Play("popup_voltar");
    }

    public void Continue()
    {
        popup_voltar_anim.Play("popup_voltar_inverse");
    }
}
