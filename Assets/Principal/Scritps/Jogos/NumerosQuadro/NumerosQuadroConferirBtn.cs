using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumerosQuadroConferirBtn : MonoBehaviour {
	AudioSource som;
	AudioClip efeito;
	public void SomaCompleta() {
		if ((NumerosQuadro.instance.numeroSorteadoUm + NumerosQuadro.instance.numeroSorteadoDois) == NumerosQuadro.instance.somaTotal) {
			Musica.instance.OnCongrats();
			NumerosQuadro.instance.panelParabens.SetActive(true);
            NumerosQuadro.instance.parabensAnim.Play("panel_parabens");
            StartCoroutine(NumerosQuadro.instance.VoltaPanelParabens());
		} else {
			Musica.instance.OnFail();
		}
	}
}
