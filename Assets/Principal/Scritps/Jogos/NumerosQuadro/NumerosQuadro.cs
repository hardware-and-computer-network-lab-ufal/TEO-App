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

	public GameObject numeroObjUm,numeroObjDois;
	public GameObject fruta;
	private Vector3 posInicial;
	private int numeroSorteadoUm, numeroSorteadoDois = 10;

	private Queue<int> unicos = new Queue<int>();
	private int dificuldade;
	public static int somaTotal = 0;

	private void Awake() {
		if (SceneManager.GetActiveScene().buildIndex == 5) {
			if ( instance == null)
				instance = this;
		}
		sortearSoma();
		somaTotal = 0;
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
		if ((numeroSorteadoUm + numeroSorteadoDois) == somaTotal) {
			print("Ganhei, total:");
			print(somaTotal);
			panelParabens.SetActive(true);
            parabensAnim.Play("panel_parabens");
            StartCoroutine(VoltaPanelParabens());
		} else {
			print((numeroSorteadoUm + numeroSorteadoDois));
			// print(numeroSorteadoUm);
			// print(numeroSorteadoDois);
			// print("Não foi dessa vez");
		}
	}
	public void sortearSoma() {
		numeroObjUm = GameObject.Find("numeroObjUm");
		numeroObjDois = GameObject.Find("numeroObjDois");

		numeroSorteadoUm = numeroSorteadoDois = 10;

		while((numeroSorteadoUm + numeroSorteadoDois) > 10) {
			int tmpUm = Random.Range(0,10);
			int tmpDois = Random.Range(0,10);
			if((tmpUm + tmpDois) <= 10) {
				numeroSorteadoUm = tmpUm;
				numeroSorteadoDois = tmpDois;
			}
		}

        string strNumUm = numeroSorteadoUm.ToString();
		print(strNumUm);
        string strNumDois = numeroSorteadoDois.ToString();
		print(strNumDois);

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
		GameObject InFruta = Instantiate(fruta, posInicial, fruta.transform.rotation);
		
			
		InFruta.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Jogos/NumerosQuadro/" + frutas[deliciaFrutosa]);
	}

	void Start () {
		fruta = GameObject.Find("fruta");
		panelParabens = GameObject.Find("panel_parabens");
		panelParabensFinal = GameObject.Find("panel_parabens_final");
		

		StartCoroutine(DesligaPanel());
		dificuldade = PlayerPrefs.GetInt("nivel");

		posInicial = new Vector3(fruta.transform.position.x, fruta.transform.position.y, fruta.transform.position.z);
		criarFruta();
		fruta.transform.position = new Vector3(10.27f, -10.81f, 0);
	}
	
	void Update () {
	}
}
