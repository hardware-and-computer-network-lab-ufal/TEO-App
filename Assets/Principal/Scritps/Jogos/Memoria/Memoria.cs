using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Memoria : MonoBehaviour {
	public static Memoria instance = null;
	public GameObject panelParabens;
	public GameObject panelParabensFinal;
	private Animator parabensAnim;

	public AudioSource som;
	private AudioClip efeito;
	public int contagemCards = 0;

	private int dificuldade;

	public bool peekLiberado = false;

	public Stack<GameObject> cartasMemorizar = new Stack<GameObject>();

	private void Awake() {
		if (SceneManager.GetActiveScene().buildIndex == 8) {
			if ( instance == null)
				instance = this;
		}
		panelParabensFinal = GameObject.Find("panel_parabens_final");
		panelParabensFinal.SetActive(false);
	
		contagemCards = 0;
		dificuldade = PlayerPrefs.GetInt("nivel", 3);
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

	public Queue<int> sortearFase() {
		Queue<int> fases = new Queue<int>();
		System.Random ordemFase = new System.Random();
		
		if (dificuldade == 1) {
			while (fases.Count != 1) {
				int numero = ordemFase.Next(1,4);
				if (!fases.Contains(numero))
					fases.Enqueue(numero);
			}
		} else if (dificuldade == 2) {
			while (fases.Count != 2) {
				int numero = ordemFase.Next(1,4);
				if (!fases.Contains(numero))
					fases.Enqueue(numero);
			}
		} else {
			while (fases.Count != 3) {
				int numero = ordemFase.Next(1,4);
				if (!fases.Contains(numero))
					fases.Enqueue(numero);
			}
		}
		return fases;
	}
	public Queue<string> sortearCards() {
		Queue<string> unicos = new Queue<string>();
		System.Random ordem = new System.Random();

		Queue<int> fases = sortearFase();

		while (fases.Count != 0) {
			int count = 0;
			int fase = fases.Dequeue();
			while (count != 4) {
				int escolhido = ordem.Next(1,5);
				if (!unicos.Contains(escolhido+"."+fase)) {
					unicos.Enqueue(escolhido+"."+fase);
					count++;
				}
			}
		}

		return unicos;
	}

	public List<GameObject> selecionarSequencia(string complemento) {
		List<GameObject> final = new List<GameObject>();
		Queue<string> cardsEscolhidos = sortearCards();

		/* O complemento é usado para diferenciar os cards que serão arrastados dos fixos, 
		   e ainda assim mantendo ambos em ordem aleatória.
		   complemento == " (1)" representa os cards que serão arrastados, 
		   já complemento == "" representa os cards que serão fixos. */

		while (cardsEscolhidos.Count != 0) {
			string elemento = cardsEscolhidos.Dequeue();
			final.Add(GameObject.Find(elemento+complemento));
		}
		return final;
	}
	public void posicionarCards() {
		List<GameObject> cards = selecionarSequencia("");

		float xStart = -5f;
		float yNovaLinha = 0f;
		int countCards = 0;

		/* Posicionando os círculos aleatórios na tela */
		foreach (GameObject item in cards) {
			if (countCards == 4) {
				if (dificuldade == 2) {
					yNovaLinha = 3f;
				} else {
					yNovaLinha += 2.1f;
				}
				xStart = -5f;
				countCards = 0;
			}
			item.transform.position = new Vector3(xStart, (1.8f - yNovaLinha), 0f);
			xStart +=2.5f;
			countCards++;
		}

		StartCoroutine(memorize(cards));
	}

	public void posicionarCardsDeEscolha() {
		List<GameObject> escolha = selecionarSequencia(" (1)");
		float zChange = 95f;
		int ordem = 10;

		foreach (GameObject item in escolha) {
			item.transform.position = new Vector3(5f, -2.4f, zChange);
			zChange+=1f;
			item.GetComponent<SpriteRenderer>().sortingOrder = ordem++;
			cartasMemorizar.Push(item);
		}
		escolha = null;
	}

	public IEnumerator memorize(List<GameObject> cartas) {
		yield return new WaitForSeconds(10);
		foreach (var item in cartas) {
			item.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Jogos/Memoria/costas");
		}
		peekLiberado = true;
	}

	void faseCompleta() {
		bool vitoria = false;
		if (dificuldade == 1) {
			if (contagemCards == 4){
				vitoria = true;
			}
		} else if (dificuldade == 2) {
			if (contagemCards == 8){
				vitoria = true;
			}
		} else {
			if (contagemCards == 12){
				vitoria = true;
			}
		}

		if (vitoria == true) {
			vitoria = false;
			contagemCards++;
			panelParabens.SetActive(true);
            parabensAnim.Play("panel_parabens");
            StartCoroutine(VoltaPanelParabens());
		}
	}

	void Start() {
		posicionarCards();
		posicionarCardsDeEscolha();

		panelParabens = GameObject.Find("panel_parabens");
		StartCoroutine(DesligaPanel());
	}

	void Update() {
		faseCompleta();
	}

}
