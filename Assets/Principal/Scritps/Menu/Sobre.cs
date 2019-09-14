using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sobre : MonoBehaviour {

    private Button sobreBtn;
    [SerializeField] private GameObject sobreTela;

	// Use this for initialization
	void Start () {
        sobreBtn = gameObject.GetComponent<Button>();

        sobreBtn.onClick.AddListener(
            () =>
            {
                GameObject.Find("Teo-Main").SetActive(false);
                GameObject.Find("Menu").SetActive(false);
                sobreTela.SetActive(true);
                TEOManager.instance.MudaIdioma();
            }    
        );
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
