using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumerosQuadroConferirBtn : MonoBehaviour {
	AudioSource som;
	AudioClip efeito;
	public void SomaCompleta() {
		if ((NumerosQuadro.instance.numeroSorteadoUm + NumerosQuadro.instance.numeroSorteadoDois) == NumerosQuadro.instance.somaTotal) {
			Musica.instance.OnCongrats();
			NumerosQuadro.instance.usuario.quantidadeAcertos++;
			NumerosQuadro.instance.usuario.tempoJogo = (int)Time.timeSinceLevelLoad;
			TelaEstatisticas.instance.FaseCompleta(NumerosQuadro.instance.usuario);
		} else {
			Musica.instance.OnFail();
			NumerosQuadro.instance.usuario.quantidadeErros++;
		}
	}
}
