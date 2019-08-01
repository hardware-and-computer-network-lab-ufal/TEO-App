using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoresDetect : MonoBehaviour {

	private Collision2D atualColisao;

	void OnCollisionEnter2D (Collision2D obj) {
		Musica.instance.OnPositionated();
		if (obj.gameObject.name == gameObject.name + " (1)"){
			Cores.instance.destroyCircle = 1;
			atualColisao = obj;
		}
		gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
	}

	void OnCollisionExit2D (Collision2D obj) {
		if (obj.gameObject.name == gameObject.name + " (1)"){
			Cores.instance.destroyCircle = 0;
			atualColisao = null;
		}
		gameObject.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
	}

	void Update(){
		if (Cores.instance.destroyCircle == 2){
			Musica.instance.OnRight();
			Cores.instance.usuario.quantidadeAcertos++;
			Destroy(atualColisao.gameObject, 0.2f);
			Destroy(gameObject, 0.2f);
			Cores.instance.contagemCores++;
			Cores.instance.destroyCircle = 0;
		}
	}
}
