using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.IO;

public class NumerosQuadro : MonoBehaviour {

	public static NumerosQuadro instance;
	public static GameObject panelParabens;
	public static GameObject panelParabensFinal;
	private Animator parabensAnim;

	public static bool criarNovaFruta = true;

	public GameObject numeroObjUm,numeroObjDois, fruta;
	private int numeroSorteadoUm, numeroSorteadoDois = 10;

	public static int contagemTotal = 0;

	private Queue<int> unicos = new Queue<int>();
	private int dificuldade;

	private void Awake() {
		if (SceneManager.GetActiveScene().buildIndex == 5) {
			if ( instance == null)
				instance = this;
		}
		contagemTotal = 0;
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

	public void SomaCompleta() {
		if (numeroSorteadoUm + numeroSorteadoDois == contagemTotal) {
			panelParabens.SetActive(true);
            parabensAnim.Play("panel_parabens");
            StartCoroutine(VoltaPanelParabens());
		}
	}
	public void sortearSoma() {
		// numeroObjUm = GameObject.Find("numeroObjUm");
		// numeroObjDois = GameObject.Find("numeroObjDois");

		do {
			numeroSorteadoUm = Random.Range(0,10);
			numeroSorteadoDois = Random.Range(0,10);
		} while (numeroSorteadoUm + numeroSorteadoDois > 10);

        print(string.Format("Numeros: {0} {1}", numeroSorteadoUm, numeroSorteadoDois));

        string strNumUm = numeroSorteadoUm.ToString();
        string strNumDois = numeroSorteadoDois.ToString();

		numeroObjUm.GetComponent<RawImage>().texture = Resources.Load("Jogos/NumerosQuadro/numeros/" + strNumUm) as Texture2D;
		numeroObjDois.GetComponent<RawImage>().texture = Resources.Load("Jogos/NumerosQuadro/numeros/" + strNumDois) as Texture2D;
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

	public void criarFruta() {
		if (criarNovaFruta == false)
			return;
		/*
			1- Laranja
			2- Maca
			3- Morango
			4- Uva
		 */
		string[] frutas = new string[4];
		frutas[0] = "Laranja";
		frutas[1] = "Maca";
		frutas[2] = "Morango";
		frutas[3] = "Uva";
		System.Random ran = new System.Random();
		int deliciaFrutosa = ran.Next(4);
		fruta.GetComponent<RawImage>().texture = Resources.Load("Jogos/NumerosQuadro/" + frutas[deliciaFrutosa]) as Texture2D;
		print(fruta.GetComponent<RawImage>().texture);
		if (fruta.GetComponent<RawImage>().texture != null) {
			criarNovaFruta = false;
			return;
		}
			

		GameObject InFruta = Instantiate(fruta) as GameObject;
		InFruta.GetComponent<RawImage>().texture = Resources.Load("Jogos/NumerosQuadro/" + frutas[deliciaFrutosa]) as Texture2D;



		criarNovaFruta = false;
	}

	void Start () {
		panelParabens = GameObject.Find("panel_parabens");
		panelParabensFinal = GameObject.Find("panel_parabens_final");
		

		StartCoroutine(DesligaPanel());
		dificuldade = PlayerPrefs.GetInt("nivel");

		sortearSoma();
	}
	
	void Update () {
		criarFruta();
		SomaCompleta();
	}
}
