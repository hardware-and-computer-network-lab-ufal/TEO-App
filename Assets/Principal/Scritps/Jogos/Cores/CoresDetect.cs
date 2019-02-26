using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoresDetect : MonoBehaviour {

	
	void OnCollisionEnter2D (Collision2D obj) {
		if (obj.gameObject.name == gameObject.name + " (1)") {
			Destroy(obj.gameObject);
			Destroy(gameObject);
			Cores.contagemCores++;
			print(Cores.contagemCores);
			// StartCoroutine("CorSelecionada");
		}
	}
}
