using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cores : MonoBehaviour {

	public static Cores instance;
	public static GameObject panelParabens;
	public static GameObject panelParabensFinal;
	private Animator parabensAnim;

	private int contagemCores = 0;
	private int dificuldade;

	private void Awake() {
		if (SceneManager.GetActiveScene().buildIndex == 2) {
			if ( instance == null)
				instance = this;
		}
	}

	IEnumerator DesligaPanel () {
		yield return new WaitForSeconds(0.001f);
		parabensAnim = panelParabens.GetComponent<Animator>();
		panelParabens.SetActive(false);
		panelParabensFinal.SetActive(false);

	}

	IEnumerator VoltaPanelParabens() {
		yield return new WaitForSeconds(5);
		parabensAnim.Play("painel_parabens_reverse");
		yield return new WaitForSeconds(1);
		panelParabensFinal.SetActive(true);
		panelParabens.SetActive(true);
	}

	public void JogarNovamente() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

	}

	public void CoresCompletas(int coresTotais) {
		if (coresTotais == contagemCores) {
			panelParabens.SetActive(true);
			parabensAnim.Play("panel_parabens");
			StartCoroutine("VoltaPanelParabens");
		}
	}

	public void CarregarCores() {
		List<GameObject> circulos = new List<GameObject>();

		System.Random ordem = new System.Random();
		Queue<int> unicos = new Queue<int>();
		Stack<int> escolha = new Stack<int>();

		string[]  coresIndex = new string[7];
		coresIndex[1] = "COR-AMARELO";
		coresIndex[2] = "COR-AZUL";
		coresIndex[3] = "COR-LARANJA";
		coresIndex[4] = "COR-ROXO";
		// coresIndex[4] = "ignore";
		coresIndex[5] = "COR-VERDE";
		coresIndex[6] = "COR-VERMELHO";

		float xStart = -4.7f;
		float yNovaLinha = 0f;
		int countCirculos = 0;
		
		/*
			1- Amarelo
			2- Azul
			3- Laranja
			4- Roxo
			5- Verde
			6- Vermelho
		 */

		/* Condicional responsável por sortear as cores que irão aparecer */
		if (dificuldade == 1) {
			while (unicos.Count != 2){
				int numero = ordem.Next(1,7);
				if(!unicos.Contains(numero))
					unicos.Enqueue(numero);
			}
		} else if (dificuldade == 2){
			while (unicos.Count != 4){
				int numero = ordem.Next(1,7);
				if(!unicos.Contains(numero))
					unicos.Enqueue(numero);
			}
		} else {
			while (unicos.Count != 6){
				int numero = ordem.Next(1,7);
				if(!unicos.Contains(numero))
					unicos.Enqueue(numero);
			}
		}

		while (unicos.Count != 0) {
			int elemento = unicos.Dequeue();
			circulos.Add(GameObject.Find(coresIndex[elemento]));
		}

		foreach (var item in circulos) {
			if (countCirculos == 3) {
				yNovaLinha = 2.9f;
				xStart = -4.7f;
			}
			item.transform.position = new Vector3(xStart, (yNovaLinha -2.7f), 0f);
			// item.transform.Translate(xStart, -2.7f, 0f);
			xStart +=2.9f;
			countCirculos++;
			
			print(item.transform.position);
		}

	}

	public void SalvaPontos(int pontosNovos) {
		if (PlayerPrefs.HasKey("pontos")) {
			int pontosAtuais = PlayerPrefs.GetInt("pontos");
			PlayerPrefs.SetInt("pontos", (pontosAtuais + pontosNovos));
		} else {
			PlayerPrefs.SetInt("pontos", pontosNovos);
		}
	}

	public void TiraPontos(int pontos) {
		SalvaPontos(-pontos);
	}

	public int PegarPontos() {
		return PlayerPrefs.GetInt("pontos");
	}
	void Start () {
		// dificuldade = PlayerPrefs.GetInt("nivel");
		dificuldade = 3;
		CarregarCores();
	}
	
	// Update is called once per frame
	void Update () {
		if (dificuldade == 1)
			CoresCompletas(2);
		else if (dificuldade == 2)
			CoresCompletas(4);
		else
			CoresCompletas(6);
	}
}
