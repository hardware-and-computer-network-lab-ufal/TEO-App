using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefIdioma : MonoBehaviour {

    [SerializeField]private Image idiomaAtualImage,idiomaAtualText;
    private Button espanholBtn, inglesBtn, francesBtn, italianoBtn;

	// Use this for initialization
	void Start () {
        
        idiomaAtualImage = GameObject.Find("idioma_atual").GetComponent<Image>();
        idiomaAtualText = GameObject.Find("idioma_texto").GetComponent<Image>();

        espanholBtn = GameObject.Find("espanhol_btn").GetComponent<Button>();
        inglesBtn = GameObject.Find("ingles_btn").GetComponent<Button>();
        francesBtn = GameObject.Find("frances_btn").GetComponent<Button>();
        italianoBtn = GameObject.Find("italiano_btn").GetComponent<Button>();

        espanholBtn.onClick.AddListener(() => IdiomaButton(espanholBtn));
        inglesBtn.onClick.AddListener(() => IdiomaButton(inglesBtn));
        francesBtn.onClick.AddListener(() => IdiomaButton(francesBtn));
        italianoBtn.onClick.AddListener(() => IdiomaButton(italianoBtn));

        francesBtn.interactable = false;
        italianoBtn.interactable = false;

        if (PlayerPrefs.HasKey("novoIdioma"))
        {
            string novoIdioma = PlayerPrefs.GetString("novoIdioma");

            Button btn = GameObject.Find(novoIdioma+"_btn").GetComponent<Button>();

            IdiomaButton(btn);

            //TEOManager.instance.MudaIdioma();
        }
        
    }
	

    void IdiomaButton(Button btn)
    {
        string oldName = idiomaAtualImage.sprite.name; //pega o nome do idioma anterior atraves do nome da imagem associada
        Sprite oldImage = idiomaAtualImage.sprite; //pega a imagem do idioma anterior
        
        idiomaAtualImage.sprite = btn.GetComponent<Image>().sprite; // muda a imagem do botao do idioma atraves do nome do botao passado - q tera o nome do novo idioma e a img associada desse idioma tb
        string novoIdioma = idiomaAtualImage.sprite.name;
        idiomaAtualText.sprite = Resources.Load<Sprite>("TextoIdiomas/" + novoIdioma);

        PlayerPrefs.SetString("novoIdioma", novoIdioma);

        btn.GetComponent<Image>().sprite = oldImage;
        btn.name = oldName+"_btn";

        TEOManager.instance.MudaIdioma();
    }
}
