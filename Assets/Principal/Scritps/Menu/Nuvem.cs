using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuvem : MonoBehaviour {

	public float velocidade;
	public Transform coordenadas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()	{
		
		if (coordenadas.position.x <= 10) {
			transform.position = new Vector3 (transform.position.x + (velocidade * Time.deltaTime), transform.position.y, transform.position.z);
		} else {
			transform.position = new Vector3 (-19.33f, transform.position.y, transform.position.z);
		}

	}
}