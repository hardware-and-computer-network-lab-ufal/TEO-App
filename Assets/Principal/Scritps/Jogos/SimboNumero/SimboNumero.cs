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
    public GameObject panelParabens;
    public GameObject panelParabensFinal;
    public GameObject popup_voltar;
    private Animator parabensAnim, popup_voltar_anim;


    public GameObject numerosObjUnid,numerosObjDez;
    private Image numObj;

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
    }

    // Use this for initialization
    void Start () {
        PlayerPrefs.DeleteKey("pontos");

        StartCoroutine(DesligaPanel());

        numSorteadoUnid = Random.Range(1,10);
        numSorteadoDez = Random.Range(0,2);
        print("NUM SORTEADO:"+(numSorteadoDez*10+numSorteadoUnid));

        string strNumUnid = numSorteadoUnid.ToString();
        string strNumDez = numSorteadoDez.ToString();

        numerosObjUnid.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Jogos/numeros/" + strNumUnid);
        numerosObjDez.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Jogos/numeros/" + strNumDez);    
        
		
	}
   
	
    IEnumerator DesligaPanel()
    {
        yield return new WaitForSeconds(0.001f);
        parabensAnim = panelParabens.GetComponent<Animator>();
        popup_voltar_anim = popup_voltar.GetComponent<Animator>();
        popup_voltar.SetActive(false);
        panelParabens.SetActive(false);
        panelParabensFinal.SetActive(false);
    }

    IEnumerator VoltaPanelParabens()
    {
        yield return new WaitForSeconds(5); 
        parabensAnim.Play("panel_parabens_reverse");
        yield return new WaitForSeconds(1);
        panelParabensFinal.SetActive(true);
        panelParabens.SetActive(false);
    }
    
    public void JogarNovamente()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void VerificaContagem()
    {
        contagem = PegaPontos();
        if (this.contagem == (this.numSorteadoDez*10+this.numSorteadoUnid))
        {
            panelParabens.SetActive(true);
            parabensAnim.Play("panel_parabens");
            StartCoroutine(VoltaPanelParabens());
        }
        else
        {
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

    public void VoltarPopup()
    {
        popup_voltar.SetActive(true);
        popup_voltar_anim.Play("popup_voltar");
    }
}
