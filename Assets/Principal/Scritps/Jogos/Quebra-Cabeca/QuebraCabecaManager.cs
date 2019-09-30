using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuebraCabecaManager : MonoBehaviour {

    public static QuebraCabecaManager instance;
    private int contador_pecas; //Vai contar quantas pecas ja foram colocadas no lugar
    public GameObject fundo;

    public UsuarioJoga usuario;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //temporariamente
		usuario.cpf = PlayerPrefs.GetString("cpf", "12345678901");
        usuario.nomeJogo = "Quebra-Cabeça";
    }

    void Start () {
        StartCoroutine(TelaEstatisticas.instance.DesligaPanel());

        if (PlayerPrefs.GetInt("nivel") == 3)
        {
            //print(fundo.gameObject.GetComponentsInChildren<SpriteRenderer>());
            //for(int i = 0; i < 4; i++)
            //{
            //    print(fundo.gameObject.GetComponentsInChildren<SpriteRenderer>()[i]);
            //}
            for (int i=0;i<4;i++)
            {
                Sprite img = Resources.Load<Sprite>("Jogos/quebracabeca/pecas_brancas/"+(i+1)+"_4");
                fundo.gameObject.GetComponentsInChildren<Image>()[i].sprite = img;
            }
        }

    }

    public void ContaPecas()
    {
        contador_pecas++;

        if (contador_pecas == 4)
        {
            usuario.quantidadeAcertos = contador_pecas;
            usuario.tempoJogo = (int)Time.timeSinceLevelLoad;
            TelaEstatisticas.instance.FaseCompleta(usuario);
        } 
    }
}
