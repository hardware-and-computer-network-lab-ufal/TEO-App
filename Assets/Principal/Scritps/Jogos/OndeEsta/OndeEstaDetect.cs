using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OndeEstaDetect : MonoBehaviour {
	bool controller;

	public void detectClicked(string parte) {
		Vector3 locationMouse;
		RaycastHit2D hit;

		locationMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		hit = Physics2D.Raycast(locationMouse, Vector2.zero);

		if (hit.collider != null && hit.transform.gameObject.name == parte) {
			Musica.instance.OnRight();
			OndeEsta.instance.contagemOndeEsta++;
			OndeEsta.instance.changeQuestion = true;
			
		} else if (hit.collider != null && hit.transform.gameObject.name != parte) {
			Musica.instance.OnFail();
		}

	}
	void Update() {
		controller = Input.GetMouseButtonDown(0);
		if (controller == true) {
			if (OndeEsta.instance.questao == 0) {
				detectClicked("olho");
			} else if (OndeEsta.instance.questao == 1) {
				detectClicked("nariz");
			} else if (OndeEsta.instance.questao == 2) {
				detectClicked("boca");
			}
		}
	}
}
