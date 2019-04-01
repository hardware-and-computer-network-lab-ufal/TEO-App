using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoresDetect : MonoBehaviour {

	
	void OnCollisionEnter2D (Collision2D obj) {
		Cores.instance.destroyCircle = 1;
		if (obj.gameObject.name == gameObject.name + " (1)" && (Cores.instance.destroyCircle == 2)) {
			Destroy(obj.gameObject, 0.2f);
			Destroy(gameObject, 0.2f);
			Cores.instance.contagemCores++;
			
			obj.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
		}
	}
}
