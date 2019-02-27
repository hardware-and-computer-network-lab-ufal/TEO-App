using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoresDetect : MonoBehaviour {

	
	void OnCollisionEnter2D (Collision2D obj) {
		if (obj.gameObject.name == gameObject.name + " (1)") {
			// obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
			// gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
			Destroy(obj.gameObject, 0.2f);
			Destroy(gameObject, 0.2f);
			Cores.contagemCores++;
			// print(Cores.contagemCores);
		}
	}
}
