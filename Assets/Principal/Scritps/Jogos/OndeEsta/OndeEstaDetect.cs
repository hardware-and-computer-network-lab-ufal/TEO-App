using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OndeEstaDetect : MonoBehaviour {

	public AudioSource som;
	private AudioClip efeito;
	bool controller;

	public void detectClicked(string parte) {
		Vector3 locationMouse;
		RaycastHit2D hit;

		locationMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		hit = Physics2D.Raycast(locationMouse, Vector2.zero);

		if (hit.collider != null && hit.transform.gameObject.name == parte) {
			som = GetComponent<AudioSource>();
			som.Stop();
			efeito = Resources.Load<AudioClip>("Som/Acertou");
			som.PlayOneShot(efeito);
			OndeEsta.contagemOndeEsta++;
			OndeEsta.changeQuestion = true;
			
		} else if (hit.collider != null && hit.transform.gameObject.name != parte) {
			som = GetComponent<AudioSource>();
			som.Stop();
			efeito = Resources.Load<AudioClip>("Som/Errou");
			som.PlayOneShot(efeito);
		}

	}
	void Update() {
		controller = Input.GetMouseButtonDown(0);
		if (controller == true) {
			if (OndeEsta.questao == 0) {
				detectClicked("olho1");
			} else if (OndeEsta.questao == 1) {
				detectClicked("nariz");
			} else if (OndeEsta.questao == 2) {
				detectClicked("boca");
			}
		}
	}
}
