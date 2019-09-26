using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.IO;

public class NumerosQuadro : MonoBehaviour {

	public static NumerosQuadro instance;

	public static bool criarNovaFruta = true;

	public GameObject numeroObjUm,numeroObjDois;
	public GameObject fruta;
	private Vector3 posInicial;
	public int numeroSorteadoUm, numeroSorteadoDois;

	public UsuarioJoga usuario;

	public int somaTotal = 0;

	private void Awake() {
		if (SceneManager.GetActiveScene().buildIndex == 7) {
			if ( instance == null)
				instance = this;
		}
        TEOManager.instance.MudaIdioma();
		//temporariamente
		usuario.cpf = PlayerPrefs.GetString("cpf", "12345678901");
		usuario.nomeJogo = "Quanto É?";
		sortearSoma();
		somaTotal = 0;
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
        string strNumDois = numeroSorteadoDois.ToString();

		numeroObjUm.GetComponent<RawImage>().texture = Resources.Load("Jogos/NumerosQuadro/numeros/" + strNumUm) as Texture2D;
		numeroObjDois.GetComponent<RawImage>().texture = Resources.Load("Jogos/NumerosQuadro/numeros/" + strNumDois) as Texture2D;
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
        TEOManager.instance.MudaIdioma();
		StartCoroutine(TelaEstatisticas.instance.DesligaPanel());


		posInicial = new Vector3(fruta.transform.position.x, fruta.transform.position.y, fruta.transform.position.z);
		criarFruta();
		fruta.transform.position = new Vector3(10.27f, -10.81f, 0);
	}
}
