using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;


public class Conexao : MonoBehaviour {
    private WWWForm form;
    private string tokenGlobal;

    public Conexao() {
        form = new WWWForm();
    }
    public void addCampo(string campo, string valor) {
        form.AddField(campo, valor);
    }

    private T upPost<T>(string url, WWWForm dados) {
        UnityWebRequest www = UnityWebRequest.Post(url, dados);
        www.SendWebRequest();

        while(!www.isDone || !www.isNetworkError){}

        if (www.isNetworkError) {
            return default(T);
        }

        return JsonUtility.FromJson<T>(www.downloadHandler.text);
    }
    
    private T upGet<T>(string url, Dictionary<string,string> dados) {
        UnityWebRequest www = UnityWebRequest.Get(url);
        foreach(string key in dados.Keys) {
            www.SetRequestHeader(key, dados[key]);
        }
        
        www.SendWebRequest();

        while(!www.isDone || !www.isNetworkError){}

        if (www.isNetworkError) {
            return default(T);
        }

        return JsonUtility.FromJson<T>(www.downloadHandler.text);
    }

    public void connect() {
        WWWForm login = new WWWForm();
        login.AddField("username", "admin");
        login.AddField("password", "admin1234");

        // while (www.isDone == false) {
        //     print("teste");
        // }
        
        var teste = upPost<Token>("http://127.0.0.1:8000/api-token/", login);
        
        // tokenGlobal = teste.token;
        print(teste.token);
    }

    // public void getUsuarioJoga(){
    //     WWWForm acesso = new WWWForm();
    //     acesso.headers.Add("Authorization",("Token "+tokenGlobal));

    //     var teste = upGet("localhost:8000/api/", acesso) as Usuario;

    //     print(teste.cpf + ": " + teste.nome);

    // }
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

// [System.Serializable]
// public class 

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