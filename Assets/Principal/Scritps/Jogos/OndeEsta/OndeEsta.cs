using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OndeEsta : MonoBehaviour {

	public static OndeEsta instance;
	public int contagemOndeEsta = 0;
	public int totalOndeEsta; // Quantidade de perguntas, definidas pela dificuldade
	 public int questao;
	public bool changeQuestion = true;

	public UsuarioJoga usuario;

	private Queue<int> bodyParts = new Queue<int>(3);

	private void Awake() {
		if (SceneManager.GetActiveScene().buildIndex == 6) {
			if ( instance == null)
				instance = this;
		}
        TEOManager.instance.MudaIdioma();
		contagemOndeEsta = 0;

		totalOndeEsta = PlayerPrefs.GetInt("nivel", 3);
		//temporariamente
		usuario.cpf = PlayerPrefs.GetString("cpf", "12345678901");
		usuario.nomeJogo = "Onde Está?";
	}

	public void JogarNovamente() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

	}

	public void OndeEstaCompleto() {
		if (totalOndeEsta == contagemOndeEsta) {
			usuario.quantidadeAcertos = contagemOndeEsta;
			usuario.tempoJogo = (int)Time.timeSinceLevelLoad;
			TelaEstatisticas.instance.FaseCompleta(usuario);
			contagemOndeEsta++;
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

            string idioma = "portugues";
            if (PlayerPrefs.HasKey("novoIdioma"))
            {
                idioma = PlayerPrefs.GetString("novoIdioma");
            }
            
			questionPlace.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Idiomas/"+idioma+"/ondeEsta/" + ques[questao]);

			changeQuestion = false;
		}
	}

	void Start () {
        TEOManager.instance.MudaIdioma();
        randomChild();
		randomParts();

		StartCoroutine(TelaEstatisticas.instance.DesligaPanel());
	}
	
	void Update () {
		questions();
		OndeEstaCompleto();
	}
}
