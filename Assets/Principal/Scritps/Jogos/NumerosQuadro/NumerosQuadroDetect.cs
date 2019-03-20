using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumerosQuadroDetect : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D obj) {
		NumerosQuadro.contagemTotal++;
		print(NumerosQuadro.contagemTotal);
		Destroy(GetComponent("NumerosQuadroDetect"), 0.2f);
	}
}
