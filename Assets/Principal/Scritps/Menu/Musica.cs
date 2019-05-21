using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour {

	public static Musica instance;
    public AudioSource musicaFundo,efeitos;
    public AudioClip somParabens, somFalha,somAcerto,somPosicionamento;

	void Awake(){
		if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
			
		} else {
			Destroy (this.gameObject);
		}

	}

    private void Update()
    {
        if (!musicaFundo.isPlaying)
        {
            musicaFundo.Play();
        }
    }

    public void OnChangeMusicVolum(float volum)
    {
        musicaFundo.volume = volum;
    }

    public void OnChangeEffectVolum(float volum) {
        efeitos.volume = volum;
    }



    public void OnCongrats()
    {
        efeitos.PlayOneShot(somParabens);
    }

    public void OnRight()
    {
        efeitos.PlayOneShot(somAcerto);
    }

    public void OnFail()
    {
        efeitos.PlayOneShot(somFalha);
    }

    public void OnPositionated()
    {
        efeitos.PlayOneShot(somPosicionamento);
    }
}

