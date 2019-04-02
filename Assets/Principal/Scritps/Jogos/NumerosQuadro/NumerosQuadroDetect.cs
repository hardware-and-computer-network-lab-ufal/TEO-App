using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumerosQuadroDetect : MonoBehaviour {
	AudioSource som;
	AudioClip efeito;
	private void OnCollisionEnter2D (Collision2D obj) {
		som = NumerosQuadro.instance.GetComponent<AudioSource>();
		som.Stop();
		efeito = Resources.Load<AudioClip>("Som/Posicionou");
		som.PlayOneShot(efeito);
		NumerosQuadro.instance.somaTotal++;
		NumerosQuadro.instance.criarFruta();
		print(NumerosQuadro.instance.somaTotal);
	}

	private void OnCollisionExit2D (Collision2D obj) {
		som = NumerosQuadro.instance.GetComponent<AudioSource>();
		som.Stop();
		efeito = Resources.Load<AudioClip>("Som/Posicionou");
		som.PlayOneShot(efeito);
		NumerosQuadro.instance.somaTotal--;
		Destroy(obj.gameObject, 0.2f);
	}
}
