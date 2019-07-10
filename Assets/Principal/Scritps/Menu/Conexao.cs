using UnityEngine;
using UnityEngine.Networking;
using System.Collections;


public class Conexao : MonoBehaviour {
    private WWWForm form = new WWWForm();
    private string tokenGlobal;

    public void addCampo(string campo, string valor) {
        form.AddField(campo, valor);
    }

    // object upPost(string url, WWWForm dados) {
        
    // }
    
    // Usuario upGet(string url, WWWForm dados) {
    //     UnityWebRequest www = UnityWebRequest.Post(url, dados);

    //     return JsonUtility.FromJson<Usuario>(www.downloadHandler.text);
    // }

    public void connect() {
        WWWForm login = new WWWForm();
        login.AddField("username", "admin");
        login.AddField("password", "admin1234");
        
        UnityWebRequest www = UnityWebRequest.Post("localhost:8000/api-token/", login);

        while (www.isDone == false) {
            print("teste");
        }
        
        var teste = JsonUtility.FromJson<Token>(www.downloadHandler.text);
        
        tokenGlobal = teste.token;
        print(tokenGlobal);
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