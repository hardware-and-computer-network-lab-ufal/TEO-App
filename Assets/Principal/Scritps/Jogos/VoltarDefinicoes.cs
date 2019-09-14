using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoltarDefinicoes : MonoBehaviour {

    [SerializeField]private GameObject menu,options, teoMain;
    private Button voltar;

	// Use this for initialization
	void Start () {

        voltar = gameObject.GetComponent<Button>();

        voltar.onClick.AddListener(
            ()=> 
            {
                menu.SetActive(true);
                options.SetActive(false);
                teoMain.SetActive(true);
                TEOManager.instance.MudaIdioma();
            }
        );
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
