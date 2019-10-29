using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimboNumero : MonoBehaviour {

    public static SimboNumero instance;
    private int numSorteadoUnid;
    private int numSorteadoDez;
    [SerializeField]
    private int contagem;


    public GameObject numerosObjUnid,numerosObjDez;
    private Image numObj;

    public UsuarioJoga usuario;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (instance == null)
            {
                instance = this;
                //DontDestroyOnLoad(this.gameObject);
            }
        }
        //temporariamente
		usuario.cpf = PlayerPrefs.GetString("cpf", "12345678901");
        usuario.nomeJogo = "Numeros";
    }

    // Use this for initialization
    void Start () {
        TEOManager.instance.MudaIdioma();
		StartCoroutine(TelaEstatisticas.instance.DesligaPanel());
        PlayerPrefs.DeleteKey("pontos");

        numSorteadoUnid = Random.Range(1,10);
        numSorteadoDez = Random.Range(0,2);
        print("NUM SORTEADO:"+(numSorteadoDez*10+numSorteadoUnid));

        string strNumUnid = numSorteadoUnid.ToString();
        string strNumDez = numSorteadoDez.ToString();

        numerosObjUnid.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Jogos/numeros/" + strNumUnid);
        numerosObjDez.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Jogos/numeros/" + strNumDez);    
        
		
	}

    public void VerificaContagem()
    {
        contagem = PegaPontos();
        if (this.contagem == (this.numSorteadoDez*10+this.numSorteadoUnid))
        {
            usuario.quantidadeAcertos++;
            usuario.tempoJogo = (int)Time.timeSinceLevelLoad;
            TelaEstatisticas.instance.FaseCompleta(usuario);
        }
        else
        {
            Musica.instance.OnFail();
            usuario.quantidadeErros++;
            print("Ops, não foi dessa vez");
        }
    }

    public void SalvaPontos(int pontosNovos)
    {
        if (PlayerPrefs.HasKey("pontos"))
        {
            int pontosAtuais = PlayerPrefs.GetInt("pontos");
            PlayerPrefs.SetInt("pontos", pontosAtuais + pontosNovos);
        }
        else
        {
            PlayerPrefs.SetInt("pontos", pontosNovos);
        }
        
    }

    public void TiraPontos(int pontos)
    {
        SalvaPontos(-pontos);
    }

    public int PegaPontos()
    {
        return PlayerPrefs.GetInt("pontos");
    }
}
