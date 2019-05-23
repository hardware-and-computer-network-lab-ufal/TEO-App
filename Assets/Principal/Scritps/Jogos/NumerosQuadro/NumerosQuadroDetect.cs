using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumerosQuadroDetect : MonoBehaviour {
	AudioSource som;
	AudioClip efeito;
	private void OnCollisionEnter2D (Collision2D obj) {
		Musica.instance.OnPositionated();
		NumerosQuadro.instance.somaTotal++;
		NumerosQuadro.instance.criarFruta();
	}

	private void OnCollisionExit2D (Collision2D obj) {
		Musica.instance.OnPositionated();
		NumerosQuadro.instance.somaTotal--;
		Destroy(obj.gameObject, 0.2f);
	}
}
