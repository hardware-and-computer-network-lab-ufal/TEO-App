using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumerosQuadroConferirBtn : MonoBehaviour {
	AudioSource som;
	AudioClip efeito;
	public void SomaCompleta() {
		som = NumerosQuadro.instance.GetComponent<AudioSource>();
		som.Stop();
		if ((NumerosQuadro.instance.numeroSorteadoUm + NumerosQuadro.instance.numeroSorteadoDois) == NumerosQuadro.instance.somaTotal) {
			efeito = Resources.Load<AudioClip>("Som/Parabens");
			som.PlayOneShot(efeito);
			print("Ganhei, total:");
			print(NumerosQuadro.instance.somaTotal);
			NumerosQuadro.instance.panelParabens.SetActive(true);
            NumerosQuadro.instance.parabensAnim.Play("panel_parabens");
            StartCoroutine(NumerosQuadro.instance.VoltaPanelParabens());
		} else {
			efeito = Resources.Load<AudioClip>("Som/Errou");
			som.PlayOneShot(efeito);
		}
	}
}
