using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Memoria : MonoBehaviour {
	public static Memoria instance = null;
	public UsuarioJoga usuario;

	public int contagemCards = 0;

	private int dificuldade;

	public bool peekLiberado = false;

	public Stack<GameObject> cartasMemorizar = new Stack<GameObject>();
	private bool vitoria = false;

	private void Awake() {
		if (SceneManager.GetActiveScene().buildIndex == 8) {
			if ( instance == null)
				instance = this;
		}
        TEOManager.instance.MudaIdioma();
		dificuldade = PlayerPrefs.GetInt("nivel", 3);
		posicionarCardsDeEscolha();
		//temporariamente
		usuario.cpf = PlayerPrefs.GetString("cpf", "12345678901");
		usuario.nomeJogo = "Memoria";
		contagemCards = 0;
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
	public List<GameObject> posicionarCards() {
		List<GameObject> cards = selecionarSequencia("");
		List<GameObject> cardsEsc = new List<GameObject>();

		float xStart = -5f;
		float yNovaLinha = 0f;
		int countCards = 0;

		/* Posicionando os círculos aleatórios na tela */
		foreach (GameObject item in cards) {
			cardsEsc.Add(GameObject.Find(item.name+" (1)"));
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

		return cardsEsc;
	}

	public void posicionarCardsDeEscolha() {
		List<GameObject> escolha = posicionarCards();
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
		int ordem = 10; // altera o sorting layer order para cada card
		
		GameObject primeiraCard = GameObject.Find("costas");
		foreach (int indice in novosUnicos) {
			escolha[indice].transform.position = new Vector3(5f, -2.4f, zChange);
			zChange+=1f;
			escolha[indice].GetComponent<SpriteRenderer>().sortingOrder = ordem++;
			cartasMemorizar.Push(escolha[indice]);
		}
		primeiraCard.transform.position = new Vector3(5f, -2.4f,zChange);
		primeiraCard.GetComponent<SpriteRenderer>().sortingOrder = ordem++;
		zChange+=1;
		cartasMemorizar.Push(primeiraCard);

		escolha = null;
	}

	public IEnumerator memorize(List<GameObject> cartas) {
		yield return new WaitForSeconds(10);
		foreach (var item in cartas) {
			item.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Jogos/Memoria/costas");
		}
		peekLiberado = true;
		Destroy(cartasMemorizar.Pop());
	}

	void faseCompleta() {
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
			usuario.quantidadeAcertos = contagemCards;
			usuario.tempoJogo = (int)Time.timeSinceLevelLoad;
			contagemCards++;
			TelaEstatisticas.instance.FaseCompleta(usuario);
		}
	}

	void Start() {
        TEOManager.instance.MudaIdioma();
		StartCoroutine(TelaEstatisticas.instance.DesligaPanel());
	}

	void Update() {
		faseCompleta();
	}

}
