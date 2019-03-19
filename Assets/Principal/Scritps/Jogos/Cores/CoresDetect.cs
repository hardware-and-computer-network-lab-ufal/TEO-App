using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;

public class CoresDetect : MonoBehaviour {

	
	void OnCollisionEnter2D (Collision2D obj) {
		if (obj.gameObject.name == gameObject.name + " (1)") {
			Destroy(obj.gameObject, 0.2f);
			Destroy(gameObject, 0.2f);
			Cores.contagemCores++;
			
			obj.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
		}
	}
}
