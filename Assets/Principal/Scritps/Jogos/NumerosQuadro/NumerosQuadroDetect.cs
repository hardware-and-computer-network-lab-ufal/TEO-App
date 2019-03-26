using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumerosQuadroDetect : MonoBehaviour {

	private void OnCollisionEnter2D (Collision2D obj) {
		NumerosQuadro.somaTotal++;
		NumerosQuadro.instance.criarFruta();
		print(NumerosQuadro.somaTotal);
	}

	private void OnCollisionExit2D (Collision2D obj) {
		NumerosQuadro.somaTotal--;
		Destroy(obj.gameObject, 0.2f);
	}
}
