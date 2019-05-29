using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumerosQuadroMoviment : MonoBehaviour {
	private Vector3 position;
	private Vector3 offset;

	void OnMouseDown() {
		position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
	}

	void OnMouseDrag() {
		Vector3 cordAtual = new Vector3(Input.mousePosition.x, Input.mousePosition.y, position.z);
		Vector3 posAtual = Camera.main.ScreenToWorldPoint(cordAtual);
		transform.position = posAtual;
	}
}
