using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TelaEstatisticas : MonoBehaviour {
	public static TelaEstatisticas instance;
    public GameObject panelParabens;
	public GameObject panel_estatisticas;
    public GameObject popup_voltar;
    private Animator parabensAnim, popup_voltar_anim;

    private TelaEstatisticas(){} 

    public void Awake() {
        instance = this;
        
        panel_estatisticas.SetActive(false);
    }

    public IEnumerator DesligaPanel () {
		yield return new WaitForSeconds(0.001f);
		parabensAnim = panelParabens.GetComponent<Animator>();

        popup_voltar_anim = popup_voltar.GetComponent<Animator>();
        popup_voltar.SetActive(false);
        panelParabens.SetActive(false);
		panel_estatisticas.SetActive(false);
	}

	public IEnumerator VoltaPanelParabens() {
		yield return new WaitForSeconds(5);
		parabensAnim.Play("panel_parabens_reverse");
		yield return new WaitForSeconds(1);
		panel_estatisticas.SetActive(true);
		panelParabens.SetActive(false);
	}

    public void PausePopup()
    {
        popup_voltar.SetActive(true);
        popup_voltar_anim.Play("popup_voltar");
    }

    public IEnumerator DesligaVoltarPanel()
    {
        yield return new WaitForSeconds(1);
        popup_voltar.SetActive(false);
    }

    public void Continue()
    {
        popup_voltar_anim.Play("popup_voltar_inverse");
        StartCoroutine(DesligaVoltarPanel());
    }

    public void FaseCompleta(UsuarioJoga usuario) {
        Musica.instance.OnCongrats();
        Login.conexao.addUsuarioJoga(usuario);
        panelParabens.SetActive(true);
        parabensAnim.Play("panel_parabens");
        StartCoroutine(VoltaPanelParabens());
    }

    public void JogarNovamente() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

	}

}
