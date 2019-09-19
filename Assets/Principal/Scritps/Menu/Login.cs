using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour {
	private Button conferir;
	private Button naoLogar;

	private GameObject campo_login;
	private GameObject campo_senha;

	public static Conexao conexao;

	// Use this for initialization
	void Start () {
		campo_login = GameObject.Find("campo_login");
		campo_senha = GameObject.Find("campo_senha");
		conferir = GameObject.Find("conferirLogin_btn").GetComponent<Button>();
		naoLogar = GameObject.Find("naologar_label").GetComponent<Button>();
		
		
		conferir.onClick.AddListener(conferirLogin);

		naoLogar.onClick.AddListener(
			() => {
				conexao = new Conexao("naoLogar", "naoLogar");
				NivelManager.instance.TelaNivel();
			}
		);
	}

	public void conferirLogin() {
		string username = campo_login.GetComponent<InputField>().text;
		string password = campo_senha.GetComponent<InputField>().text;

		try {
			conexao = new Conexao(username, password);
		}
		catch (System.Exception e) {
			print(e.Message);
			Musica.instance.OnFail();
			return;
		}

		NivelManager.instance.TelaNivel();
	}
}
