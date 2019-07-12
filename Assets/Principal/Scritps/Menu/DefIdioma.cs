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

        espanholBtn.onClick.AddListener(()=>IdiomaButton(espanholBtn));
        inglesBtn.onClick.AddListener(() => IdiomaButton(inglesBtn));
        francesBtn.onClick.AddListener(() => IdiomaButton(francesBtn));
        italianoBtn.onClick.AddListener(() => IdiomaButton(italianoBtn));
    }
	

    void IdiomaButton(Button btn)
    {
        string oldName = idiomaAtualImage.sprite.name;
        Sprite oldImage = idiomaAtualImage.sprite;
        
        idiomaAtualImage.sprite = btn.GetComponent<Image>().sprite;
        string novoIdioma = idiomaAtualImage.sprite.name;
        idiomaAtualText.sprite = Resources.Load<Sprite>("Bandeiras/"+novoIdioma);

        PlayerPrefs.SetString("novoIdioma", novoIdioma);

        btn.GetComponent<Image>().sprite = oldImage;
        btn.name = oldName+"_btn";

        TEOManager.instance.MudaIdioma();
    }
}
