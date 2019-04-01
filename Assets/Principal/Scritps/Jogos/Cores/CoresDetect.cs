using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoresDetect : MonoBehaviour {

	public static CoresDetect instance;
	private Collision2D atualColisao;
	private Color atual, fixa;

	public AudioSource som;
	void OnCollisionEnter2D (Collision2D obj) {
		som = Cores.instance.GetComponent<AudioSource>();
		AudioClip efeito = Resources.Load<AudioClip>("Som/Posicionou");
		som.PlayOneShot(efeito);
		if (obj.gameObject.name == gameObject.name + " (1)"){
			Cores.instance.destroyCircle = 1;
			atual = obj.gameObject.GetComponent<Renderer>().material.GetColor("_Color");
			fixa = gameObject.GetComponent<Renderer>().material.GetColor("_Color");
			obj.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
			atualColisao = obj;
		}
	}

	void OnCollisionExit2D (Collision2D obj) {
		if (obj.gameObject.name == gameObject.name + " (1)"){
			Cores.instance.destroyCircle = 0;
			obj.gameObject.GetComponent<Renderer>().material.color = atual;
			gameObject.GetComponent<Renderer>().material.color = fixa;
			atualColisao = null;
		}
	}

	void Update(){
		if (Cores.instance.destroyCircle == 2){
			Destroy(atualColisao.gameObject, 0.2f);
			Destroy(gameObject, 0.2f);
			Cores.instance.contagemCores++;
			Cores.instance.destroyCircle = 0;
		}
	}
}
