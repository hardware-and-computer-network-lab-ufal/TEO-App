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

	public GameObject numeroObjUm,numeroObjDois;

	public static int contagemTotal = 0;
	// public List<GameObject> circulos;
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

	public void SomaCompleta(int coresTotais) {
		if (coresTotais == contagemTotal) {
			panelParabens.SetActive(true);
            parabensAnim.Play("panel_parabens");
            StartCoroutine(VoltaPanelParabens());
		}
	}
	public void sortearSoma() {
		numeroObjUm = GameObject.Find("numeroObjUm");
		numeroObjDois = GameObject.Find("numeroObjDois");

		int numeroSorteadoUm = 10;
        int numeroSorteadoDois = 10;
		do {
			numeroSorteadoUm = Random.Range(0,10);
			numeroSorteadoDois = Random.Range(0,10);
		} while (numeroSorteadoUm + numeroSorteadoDois > 10);

        print(string.Format("Numeros: {0} {1}", numeroSorteadoUm, numeroSorteadoDois));

        string strNumUm = numeroSorteadoUm.ToString();
        string strNumDois = numeroSorteadoDois.ToString();

		// numeroObjUm.GetComponent<SpriteRenderer>().sprite = Sprite.Create(Resources.Load("Jogos/NumerosQuadro/numeros/1") as Texture2D);
		numeroObjUm.GetComponent<RawImage>().texture = Resources.Load("Jogos/NumerosQuadro/numeros/1") as Texture2D;
		// numeroObjUm.GetComponent<Renderer>().sortingOrder = 999;
		print(Resources.Load("Jogos/NumerosQuadro/numeros/1") as Object);

		// Instantiate(numeroObjUm);
		// Instantiate(numeroObjDois);
		
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
		panelParabens = GameObject.Find("panel_parabens");
		panelParabensFinal = GameObject.Find("panel_parabens_final");

		StartCoroutine(DesligaPanel());
		dificuldade = PlayerPrefs.GetInt("nivel");
		
		sortearSoma();
	}
	
	void Update () {
		// if (dificuldade == 1)
		// 	print("D: 1");
		// else if (dificuldade == 2)
		// 	print("D: 2");
		// else
		// 	print("D: 3");
	}
}
