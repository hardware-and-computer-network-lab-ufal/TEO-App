using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaClicked : MonoBehaviour {
	private Vector3 position;
	private Vector3 offset, positionDefault;

	void OnMouseDown() {
		if (Memoria.instance.peekLiberado == true){
			StartCoroutine("tempo");
		}
	}

	bool verificaSeCorreto() {
		if ((gameObject.name+" (1)") == Memoria.instance.cartasMemorizar.Peek().name) {
			Musica.instance.OnRight();
			Destroy(gameObject, 0.2f);
			GameObject tmp = Memoria.instance.cartasMemorizar.Pop();
			Destroy(tmp, 0.2f);
			Memoria.instance.peekLiberado = true;
			return true;
		}
		Musica.instance.OnFail();
		return false;
	}

	private IEnumerator tempo() {
		gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Jogos/Memoria/"+gameObject.name[2]+"/"+gameObject.name);
		Memoria.instance.peekLiberado = false;
		yield return new WaitForSeconds(2);
		if (verificaSeCorreto() == true) {
			Memoria.instance.contagemCards++;
		} else {
			gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Jogos/Memoria/costas");
			Memoria.instance.peekLiberado = true;
		}
	}
}
