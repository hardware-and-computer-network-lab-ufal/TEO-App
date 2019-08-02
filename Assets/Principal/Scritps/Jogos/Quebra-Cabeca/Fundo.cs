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
        if (outro.gameObject.CompareTag("peca") && outro.gameObject.name==this.gameObject.name) //se a peca for colocada no canto certo
        {
            Musica.instance.OnRight();
            imgFundo.sprite =  outro.gameObject.GetComponent<SpriteRenderer>().sprite;
            QuebraCabecaManager.instance.ContaPecas();
            Destroy(outro.gameObject);
        } else if(outro.gameObject.name != this.gameObject.name && !outro.gameObject.name.Contains("p"))
        {
            Musica.instance.OnFail();
            QuebraCabecaManager.instance.usuario.quantidadeErros++;
        }
    }

    
}
