using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fundo : MonoBehaviour {

    private Image imgFundo;
    

	// Use this for initialization
	void Start () {
        imgFundo = gameObject.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("peca") && outro.gameObject.name==this.gameObject.name)
        {
            print(outro.name);
            print(outro.GetComponent<SpriteRenderer>());
            imgFundo.sprite =  outro.gameObject.GetComponent<SpriteRenderer>().sprite;
            QuebraCabecaManager.instance.ContaPecas();
            Destroy(outro.gameObject);
        }
    }
}
