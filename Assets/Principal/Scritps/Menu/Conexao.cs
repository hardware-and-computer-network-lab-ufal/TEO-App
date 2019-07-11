using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Collections;


public class Conexao : MonoBehaviour {
    private WWWForm form;
    private string tokenGlobal;

    public Conexao() {
        form = new WWWForm();
        connect();
    }
    public void addCampo(string campo, string valor) {
        form.AddField(campo, valor);
    }

    private T upPost<T>(string url, WWWForm dados) {
        UnityWebRequest request = UnityWebRequest.Post(url, dados);
        if (tokenGlobal != null) {
            request.SetRequestHeader("Authorization", "Token " + tokenGlobal);
        }
        request.SendWebRequest();

        while(!request.isDone && !request.isNetworkError){}

        if (request.isNetworkError) {
            return default(T);
        }

        return JsonUtility.FromJson<T>(request.downloadHandler.text);
    }
    
    private T upGet<T>(string url, Dictionary<string,string> dados = null) {
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

    public void connect() {
        WWWForm login = new WWWForm();
        login.AddField("username", "admin");
        login.AddField("password", "admin1234");
        
        Token retorno = upPost<Token>("http://127.0.0.1:8000/api-token/", login);
        
        tokenGlobal = retorno.token;
    }

    public void getUsuarioJoga(){
        

        UsuarioLista retorno = upGet<UsuarioLista>("localhost:8000/api/");

        foreach (Usuario item in retorno.lista) {
            print(item.nome + ": " + item.cpf);
        }

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
}