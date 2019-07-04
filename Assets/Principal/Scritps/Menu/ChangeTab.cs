using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTab : MonoBehaviour {

    private Button goNewtab;
    [SerializeField]private GameObject definitionsTab, estatisticsTab;

	// Use this for initialization
	void Start () {
        goNewtab = gameObject.GetComponent<Button>();
        
        goNewtab.onClick.AddListener(()=>GoNewTab());
	}
    
	void GoNewTab()
    {
        if (gameObject.name.Equals("VaiEst"))
        {
            definitionsTab.SetActive(false);
            estatisticsTab.SetActive(true);

            //JogosManager.instance.MudaIdioma();

        } else if (gameObject.name.Equals("VaiDef"))
        {
            definitionsTab.SetActive(true);
            estatisticsTab.SetActive(false);

            //JogosManager.instance.MudaIdioma();
        }
    }

}
