using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumerosQuadroDetect : MonoBehaviour {

	private void OnCollisionEnter2D (Collision2D obj) {
		NumerosQuadro.instance.SalvaPontos(1);
		print(NumerosQuadro.instance.PegarPontos());
		// Destroy(GetComponent("NumerosQuadroDetect"), 0.2f);
	}

	private void OnCollisionExit2D (Collision2D obj) {
		NumerosQuadro.instance.TiraPontos(1);
		Destroy(obj.gameObject, 0.2f);
		print(NumerosQuadro.instance.PegarPontos());
	}
}
