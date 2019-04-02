using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoresDetect : MonoBehaviour {

	private Collision2D atualColisao;

	public AudioSource som;
	private AudioClip efeito;
	void OnCollisionEnter2D (Collision2D obj) {
		som = Cores.instance.GetComponent<AudioSource>();
		som.Stop();
		efeito = Resources.Load<AudioClip>("Som/Posicionou");
		som.PlayOneShot(efeito);
		if (obj.gameObject.name == gameObject.name + " (1)"){
			Cores.instance.destroyCircle = 1;
			atualColisao = obj;
		}
		gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
	}

	void OnCollisionExit2D (Collision2D obj) {
		if (obj.gameObject.name == gameObject.name + " (1)"){
			Cores.instance.destroyCircle = 0;
			atualColisao = null;
		}
		gameObject.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
	}

	void Update(){
		if (Cores.instance.destroyCircle == 2){
			som = Cores.instance.GetComponent<AudioSource>();
			som.Stop();
			efeito = Resources.Load<AudioClip>("Som/Acertou");
			som.PlayOneShot(efeito);
			Destroy(atualColisao.gameObject, 0.2f);
			Destroy(gameObject, 0.2f);
			Cores.instance.contagemCores++;
			Cores.instance.destroyCircle = 0;
		}
	}
}
