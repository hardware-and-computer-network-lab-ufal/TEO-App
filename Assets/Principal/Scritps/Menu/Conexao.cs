using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Collections;


public class Conexao {
	private string tokenGlobal;
	public bool conectado = false;

	public static Conexao instance;

	public Conexao(string username, string password) {
		instance = this;
		conectado = connect(username, password);
		if(username == "" || password == "") {
			throw new System.Exception("Dados incompletos!");
		} else if (conectado == false && username != "naoLogar") {
			throw new System.Exception("Dados incorretos!");
		}
	}
	// public Conexao() {
	// 	instance = this;
	// 	connect();
	// }

	private T upPost<T>(string url, WWWForm dados) {
		if(conectado == false) {
			Debug.Log("Não conectado!");
			return default(T);
		}
		UnityWebRequest request = UnityWebRequest.Post(url, dados);
		if (tokenGlobal != null) {
			request.SetRequestHeader("Authorization", "Token " + tokenGlobal);
		}
		request.SendWebRequest();

		while(!request.isDone && !request.isNetworkError && !request.isHttpError && conectado){}

		if (request.isNetworkError || request.isHttpError) {
			return default(T);
		} else {
			Debug.Log("Success");
		}

		return JsonUtility.FromJson<T>(request.downloadHandler.text);
	}
	
	private T upGet<T>(string url, Dictionary<string,string> dados = null) {
		if(conectado == false) {
			Debug.Log("Não conectado!");
			return default(T);
		}
		UnityWebRequest request = UnityWebRequest.Get(url);
		request.SetRequestHeader("Authorization", "Token " + tokenGlobal);
		if (dados != null) {
			foreach(string key in dados.Keys) {
				request.SetRequestHeader(key, dados[key]);
			}
		}
		
		request.SendWebRequest();

		while(!request.isDone && !request.isNetworkError){}

		if (request.isNetworkError) {
			return default(T);
		}

		return JsonUtility.FromJson<T>(request.downloadHandler.text);
	}

	public bool connect(string username, string password) {
		WWWForm login = new WWWForm();
		login.AddField("username", username);
		login.AddField("password", password);
		conectado = true; // para passar a tentativa de conexão
		
		Token retorno = upPost<Token>("localhost:8000/api-token/", login);
		if (retorno == default(Token)) {
			return false;
		}
		
		tokenGlobal = retorno.token;
		return true;
	}

	public Dictionary<string,string> getUsuarios() {
		UsuarioLista retorno = upGet<UsuarioLista>("localhost:8000/api/");
		Dictionary<string,string> dicio = new Dictionary<string, string>();

		foreach (Usuario item in retorno.lista) {
			dicio.Add(item.cpf, item.nome);
		}

		return dicio;
	}

	public UsuarioJogaLista getUsuarioJoga(string cpf) {
		Dictionary<string,string> dados = new Dictionary<string, string>();
		dados.Add("cpf", cpf);
		UsuarioJogaLista retorno = upGet<UsuarioJogaLista>("localhost:8000/api-jogos/", dados);
		
		return retorno;
	}

	public UsuarioJogaTotalLista GetUsuariosJogamTotal() {
		UsuarioJogaTotalLista retorno = upGet<UsuarioJogaTotalLista>("localhost:8000/api-gerais/");
		return retorno;
	}

	public void addUsuarioJoga(UsuarioJoga user) {
		WWWForm partida = new WWWForm();
		partida.AddField("cpf", user.cpf);
		partida.AddField("nomeJogo", user.nomeJogo);
		partida.AddField("tempoJogo", user.tempoJogo);
		partida.AddField("quantidadeAcertos", user.quantidadeAcertos);
		partida.AddField("quantidadeErros", user.quantidadeErros);

		UsuarioJoga retorno = upPost<UsuarioJoga>("localhost:8000/api-jogos/", partida);
	}
}

[System.Serializable]
public class Token {
	public string token;
}

[System.Serializable]
public class Usuario {
	public string cpf;
	public string nome;
}

[System.Serializable]
public class UsuarioLista {
	public List<Usuario> lista;
}

[System.Serializable]
public class UsuarioJoga {
	public int id;
	public string cpf;
	public string nomeJogo;
	public int tempoJogo;
	public int quantidadeAcertos;
	public int quantidadeErros;
	public string horario;

	public UsuarioJoga() {}
	public UsuarioJoga (string cpf, string nomeJogo, int tempoJogo, int quantidadeAcertos, int quantidadeErros) {
		this.cpf = cpf;
		this.nomeJogo = nomeJogo;
		this.tempoJogo = tempoJogo;
		this.quantidadeAcertos = quantidadeAcertos;
		this.quantidadeErros = quantidadeErros;
	}
}

[System.Serializable]
public class UsuarioJogaLista {
	public List<UsuarioJoga> lista;
}

[System.Serializable]
public class UsuarioJogaTotal {
	public string cpf;
	public string nomeJogo;
	public int tempoTotalJogo;
	public int quantidadeTotalAcertos;
	public int quantidadeTotalErros;
}
[System.Serializable]
public class UsuarioJogaTotalLista {
	public List<UsuarioJogaTotal> lista;
}