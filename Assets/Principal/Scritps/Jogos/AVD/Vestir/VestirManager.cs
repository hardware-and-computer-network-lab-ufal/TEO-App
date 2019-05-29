using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VestirManager : MonoBehaviour {

    public static VestirManager instance;

    public GameObject panelParabens;
    public GameObject panelEstatisticas;
    public GameObject popup_voltar;
    private Animator parabensAnim, popup_voltar_anim;
    public bool rightClothe = false;
    public int clothesLentgh=0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Use this for initialization
    void Start () {
        StartCoroutine(DesligaPanel());
	}

    private void Update()
    {
        VerifyClothes();
    }

    IEnumerator VoltaPanelParabens()
    {
        yield return new WaitForSeconds(5);
        parabensAnim.Play("panel_parabens_reverse");
        yield return new WaitForSeconds(1);
        panelEstatisticas.SetActive(true);
        panelParabens.SetActive(false);
    }

    private void VerifyClothes()
    {
        if (clothesLentgh == 4) //se ja tiver as quatro pecas ele acertou
        {
            panelParabens.SetActive(true);
            parabensAnim.Play("panel_parabens");
            Musica.instance.OnCongrats();
            StartCoroutine(VoltaPanelParabens());
        }
    }

    IEnumerator DesligaPanel()
    {
        yield return new WaitForSeconds(0.001f);
        parabensAnim = panelParabens.GetComponent<Animator>();
        popup_voltar_anim = popup_voltar.GetComponent<Animator>();
        panelParabens.SetActive(false);
        popup_voltar.SetActive(false);
        panelEstatisticas.SetActive(false);
    }

    IEnumerator DesligaVoltarPanel()
    {
        yield return new WaitForSeconds(1);
        popup_voltar.SetActive(false);
    }

    

    public void PausePopup()
    {
        popup_voltar.SetActive(true);
        popup_voltar_anim.Play("popup_voltar");
        //Time.timeScale = 0; //forma de pausar os objetos do jogo
    }

    public void JogarNovamente()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Continue()
    {
        //Time.timeScale = 1; //despausar jogo
        popup_voltar_anim.Play("popup_voltar_inverse");
        StartCoroutine(DesligaVoltarPanel());
    }
}
