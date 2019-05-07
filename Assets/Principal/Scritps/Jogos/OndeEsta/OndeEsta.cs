﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OndeEsta : MonoBehaviour {

	public OndeEsta instance;
	public GameObject panelParabens;
	public GameObject panelParabensFinal;
	private Animator parabensAnim;

	public AudioSource som;
	private AudioClip efeito;
	public static int contagemOndeEsta = 0;
	public static int totalOndeEsta; // Quantidade de perguntas, definidas pela dificuldade
	 public static int questao;
	public static bool changeQuestion = true;

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
		randomChild();
		randomParts();
	}

	IEnumerator DesligaPanel () {
		yield return new WaitForSeconds(0.001f);
		parabensAnim = panelParabens.GetComponent<Animator>();
		panelParabens.SetActive(false);

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
			som = GetComponent<AudioSource>();
			som.Stop();
			efeito = Resources.Load<AudioClip>("Som/Parabens");
			som.PlayOneShot(efeito);
			
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

	public void playSound(AudioClip efeito) {
		som = GetComponent<AudioSource>();
		som.Stop();
		som.PlayOneShot(efeito);
	}

	void Start () {
		panelParabens = GameObject.Find("panel_parabens");

		StartCoroutine("DesligaPanel");
	}
	
	void Update () {
		questions();
		OndeEstaCompleto();
	}
}
