using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumerosQuadroConferirBtn : MonoBehaviour {
	public void SomaCompleta() {
		if ((NumerosQuadro.instance.numeroSorteadoUm + NumerosQuadro.instance.numeroSorteadoDois) == NumerosQuadro.instance.somaTotal) {
			print("Ganhei, total:");
			print(NumerosQuadro.instance.somaTotal);
			NumerosQuadro.instance.panelParabens.SetActive(true);
            NumerosQuadro.instance.parabensAnim.Play("panel_parabens");
            StartCoroutine(NumerosQuadro.instance.VoltaPanelParabens());
		} else {
			print("Não foi dessa vez");
		}
	}
}
