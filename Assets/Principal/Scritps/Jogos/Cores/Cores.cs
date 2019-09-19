using System.Collections;
using System;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections.Generic;

public class Cores : MonoBehaviour {

	public static Cores instance;
	public GameObject panelParabens;
	public GameObject panelParabensFinal;
    public GameObject popup_voltar;
    private Animator parabensAnim, popup_voltar_anim;
	public int contagemCores = 0;

	private Queue<int> unicos = new Queue<int>();
	private int dificuldade;

	public UsuarioJoga usuario = new UsuarioJoga();
	/*  cpf = "" (Missing)
		nomeJogo = Cores
		tempoJogo = SET
		quantidadeAcertos = SET
		quantidadeErros = SET
	*/

	/* Os valores de destroyCircle podem ser 0, 1, 2:
		Caso 0: Objeto não está colidindo, nem deve ser destruído
		Caso 1: Objeto colidiu
		Caso 2: Objeto está colidindo e deve ser destruído
	 */
	public int destroyCircle = 0;

	private void Awake() {
		if (SceneManager.GetActiveScene().buildIndex == 4) {
			if ( instance == null)
				instance = this;
		}
		panelParabensFinal = GameObject.Find("panel_parabens_final");
        TEOManager.instance.MudaIdioma();
		panelParabensFinal.SetActive(false);
		contagemCores = 0;
		//temporariamente
		usuario.cpf = PlayerPrefs.GetString("cpf", "12345678901");
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

	public void CoresCompletas(int coresTotais) {
		if (coresTotais == contagemCores) {
			Musica.instance.OnCongrats();
			usuario.tempoJogo = (int)Time.timeSinceLevelLoad;
			// Login.conexao.instance.addUsuarioJoga(usuario);
			usuario.quantidadeAcertos = contagemCores;
			Login.conexao.addUsuarioJoga(usuario);

			contagemCores++;
			panelParabens.SetActive(true);
            parabensAnim.Play("panel_parabens");
            StartCoroutine(VoltaPanelParabens());
		}
	}
	public void sortearCores(){
		
		System.Random ordem = new System.Random();

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
	}
	public List<GameObject> GerarCores(string complemento) {
		List<GameObject> resultado = new List<GameObject>();
		Queue<int> coresEscolhidas = new Queue<int>();
		foreach (int item in unicos) {
			coresEscolhidas.Enqueue(item);
		}

		/* O complemento é usado para diferenciar as cores que serão arrastadas das fixas, 
		   e ainda assim mantendo ambas em ordem aleatória.
		   complemento == " (1)" representa as cores que serão arrastadas, 
		   já complemento == "" representa as cores que serão fixas. */
		string[]  coresIndex = new string[7];
		coresIndex[1] = "COR-AMARELO" + complemento;
		coresIndex[2] = "COR-AZUL" + complemento;
		coresIndex[3] = "COR-LARANJA" + complemento;
		coresIndex[4] = "COR-ROXO" + complemento;
		coresIndex[5] = "COR-VERDE" + complemento;
		coresIndex[6] = "COR-VERMELHO" + complemento;
		
		/*
			1- Amarelo
			2- Azul
			3- Laranja
			4- Roxo
			5- Verde
			6- Vermelho
		 */

		while (coresEscolhidas.Count != 0) {
			int elemento = coresEscolhidas.Dequeue();
			resultado.Add(GameObject.Find(coresIndex[elemento]));
		}

		
		return resultado;
	}
	public void CarregarCores() {
		List<GameObject> circulos = GerarCores("");

		float xStart = -4.7f;
		float yNovaLinha = 0f;
		int countCirculos = 0;

		/* Posicionando os círculos aleatórios na tela */
		foreach (GameObject item in circulos) {
			if (countCirculos == 3) {
				yNovaLinha = 2.9f;
				xStart = -4.7f;
			}
			item.transform.position = new Vector3(xStart, (yNovaLinha -2.7f), 0f);
			xStart +=2.9f;
			countCirculos++;
		}

	}

	public void CoresSeleciona() {
		List<GameObject> escolha = GerarCores(" (1)");
		Queue<int> novosUnicos = new Queue<int>();
		System.Random novaOrdemMundial = new System.Random();
		int numero;

		while (novosUnicos.Count < escolha.Count) {
			numero = novaOrdemMundial.Next(escolha.Count);
			if (!novosUnicos.Contains(numero)) {
				novosUnicos.Enqueue(numero);
			}
		}
		float zChange = 95f;

		foreach (int item in novosUnicos) {
			escolha[item].transform.position = new Vector3(5f, -2.68f, zChange);
			zChange+=1f;
		}
	}

	void Start () {
		panelParabens = GameObject.Find("panel_parabens");
        popup_voltar = GameObject.Find("popup_voltar");
        TEOManager.instance.MudaIdioma();

		StartCoroutine(DesligaPanel());
		dificuldade = PlayerPrefs.GetInt("nivel");
		
		sortearCores();
		CarregarCores();
		CoresSeleciona();
		usuario.nomeJogo = "Cores";
	}
	
	void Update () {
		if (dificuldade == 1)
			CoresCompletas(2);
		else if (dificuldade == 2)
			CoresCompletas(4);
		else
			CoresCompletas(6);
	}

    public void PausePopup()
    {
        popup_voltar.SetActive(true);
        popup_voltar_anim.Play("popup_voltar");
    }

    IEnumerator DesligaVoltarPanel()
    {
        yield return new WaitForSeconds(1);
        popup_voltar.SetActive(false);
    }

    public void Continue()
    {
        popup_voltar_anim.Play("popup_voltar_inverse");
        StartCoroutine(DesligaVoltarPanel());
    }
}
