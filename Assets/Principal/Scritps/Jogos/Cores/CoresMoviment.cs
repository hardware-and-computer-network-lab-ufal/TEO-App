using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoresMoviment : MonoBehaviour {
	public AudioSource som;
	private AudioClip efeito;
	private Vector3 position;
	private Vector3 offset, positionDefault;

	void OnMouseDown() {
		position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		positionDefault = transform.position;
	}

	void OnMouseDrag() {
		Vector3 cordAtual = new Vector3(Input.mousePosition.x, Input.mousePosition.y, position.z);
		Vector3 posAtual = Camera.main.ScreenToWorldPoint(cordAtual);
		transform.position = posAtual;
	}

	void OnMouseUp() {
		if (Cores.instance.destroyCircle == 0) {
			transform.position = positionDefault;
			som = Cores.instance.GetComponent<AudioSource>();
			som.Stop();
			efeito = Resources.Load<AudioClip>("Som/Errou");
			som.PlayOneShot(efeito);
		} else if(Cores.instance.destroyCircle == 1) {
			Cores.instance.destroyCircle = 2;
		}
	}
}
