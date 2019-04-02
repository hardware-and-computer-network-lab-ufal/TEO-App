using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumerosQuadroDetect : MonoBehaviour {

	private void OnCollisionEnter2D (Collision2D obj) {
		NumerosQuadro.instance.somaTotal++;
		NumerosQuadro.instance.criarFruta();
		print(NumerosQuadro.instance.somaTotal);
	}

	private void OnCollisionExit2D (Collision2D obj) {
		NumerosQuadro.instance.somaTotal--;
		Destroy(obj.gameObject, 0.2f);
	}
}
