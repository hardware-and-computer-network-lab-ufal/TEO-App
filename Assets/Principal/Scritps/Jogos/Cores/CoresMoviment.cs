﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoresMoviment : MonoBehaviour {

	private Vector3 position, positionAux;
	private Vector3 offset;

	void OnMouseDown() {
		position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		positionAux = transform.position;
	}

	void OnMouseDrag() {
		Vector3 cordAtual = new Vector3(Input.mousePosition.x, Input.mousePosition.y, position.z);
		Vector3 posAtual = Camera.main.ScreenToWorldPoint(cordAtual);
		transform.position = posAtual;
	}

	void OnMouseUp() {
		transform.position = positionAux;
	}
}
