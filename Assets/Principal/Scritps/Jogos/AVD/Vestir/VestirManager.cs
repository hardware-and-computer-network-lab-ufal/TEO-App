using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VestirManager : MonoBehaviour {

    public static VestirManager instance;
    public bool rightClothe = false;
    public int clothesLentgh=0;

    public UsuarioJoga usuario;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //temporariamente
		usuario.cpf = PlayerPrefs.GetString("cpf", "12345678901");
        usuario.nomeJogo = "Vestir";
    }
    // Use this for initialization
    void Start () {
        StartCoroutine(TelaEstatisticas.instance.DesligaPanel());
	}
    

    public void VerifyClothes()
    {
        if (clothesLentgh == 4) //se ja tiver as quatro pecas ele acertou
        {
            usuario.quantidadeAcertos = clothesLentgh;
            usuario.tempoJogo = (int)Time.timeSinceLevelLoad;
            TelaEstatisticas.instance.FaseCompleta(usuario);
        }
    }

    public void JogarNovamente()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
